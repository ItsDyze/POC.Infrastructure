using Integration.RINF.Contracts;
using Integration.RINF.Interfaces;
using Integration.RINF.Models;
using Newtonsoft.Json;

namespace Integration.RINF;

public class RINFManager:IRINFManager
{
    private RINFConfiguration _config;
    private HttpClient _client;

    private string? _token;
    
    public RINFManager(RINFConfiguration config)
    {
        _config = config;
        _client = new HttpClient();
    }

    public async Task<IEnumerable<BorderPoint>> GetBorderPointsAsync()
    {
        if (_token == null)
        {
            await SetToken();
        }
        
        HttpResponseMessage httpResponse = await _client.GetAsync(_config.BaseUrl + "/BorderPoints$top=5");
        httpResponse.EnsureSuccessStatusCode();
        string body = await httpResponse.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<QueryWrapper<IEnumerable<BorderPoint>>>(body)?.Value ?? Enumerable.Empty<BorderPoint>();
    }
    
    public async Task<IEnumerable<OperationalPoint>> GetOperationalPointsAsync()
    {
        if (_token == null)
        {
            await SetToken();
        }
        
        HttpResponseMessage httpResponse = await _client.GetAsync(_config.BaseUrl + "/OperationalPoints?$top=5");
        httpResponse.EnsureSuccessStatusCode();
        string body = await httpResponse.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<QueryWrapper<IEnumerable<OperationalPoint>>>(body)?.Value ?? Enumerable.Empty<OperationalPoint>();
    }

    public async Task<IEnumerable<SectionOfLine>> GetSectionsOfLineAsync()
    {
        if (_token == null)
        {
            await SetToken();
        }
        
        HttpResponseMessage httpResponse = await _client.GetAsync(_config.BaseUrl + "/SectionsOfLine?$top=5");
        httpResponse.EnsureSuccessStatusCode();
        string body = await httpResponse.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<QueryWrapper<IEnumerable<SectionOfLine>>>(body)?.Value ?? Enumerable.Empty<SectionOfLine>();
    }

    private async Task SetToken()
    {
        HttpResponseMessage httpResponse = await _client.PostAsync(_config.BaseUrl + "/token", new FormUrlEncodedContent(new []
        {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", _config.User),
            new KeyValuePair<string, string>("password", _config.Password)
        }));
        
        httpResponse.EnsureSuccessStatusCode();
        string body = await httpResponse.Content.ReadAsStringAsync();
        GetTokenResponse parsedBody = JsonConvert.DeserializeObject<GetTokenResponse>(body);
        
        _token = parsedBody.AccessToken;
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
    }
}