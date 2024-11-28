using Integration.RINF.Contracts;
using Integration.RINF.Interfaces;
using Integration.RINF.Models;
using Newtonsoft.Json;

namespace Integration.RINF;

public class RINFManager : IRINFManager
{
    private readonly RINFConfiguration _config;
    private readonly HttpClient _client;

    private bool _authenticated;
    
    public RINFManager(RINFConfiguration config)
    {
        _config = config;
        _client = new HttpClient();
        
        //_client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=full");
    }

    public async Task<IList<BorderPoint>> GetBorderPointsAsync()
    {
        if (!_authenticated)
        {
            await SetToken();
        }
        
        var httpResponse = await _client.GetAsync(_config.BaseUrl + "/BorderPoints?$top=5");
        httpResponse.EnsureSuccessStatusCode();
        var body = await httpResponse.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<QueryWrapper<IList<BorderPoint>>>(body)?.Value ?? [];
    }
    
    public async Task<IList<OperationalPoint>> GetOperationalPointsAsync()
    {
        if (!_authenticated)
        {
            await SetToken();
        }
        
        var httpResponse = await _client.GetAsync(_config.BaseUrl + "/OperationalPoints?$top=5&$filter=Country eq 'Luxembourg'&$expand=TafTapCodes");
        httpResponse.EnsureSuccessStatusCode();
        var body = await httpResponse.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<QueryWrapper<IList<OperationalPoint>>>(body)?.Value ?? [];
    }

    public async Task<IList<SectionOfLine>> GetSectionsOfLineAsync()
    {
        if (!_authenticated)
        {
            await SetToken();
        }
        
        var httpResponse = await _client.GetAsync(_config.BaseUrl + "/SectionsOfLine?$top=5&$filter=Country eq 'Luxembourg'&$expand=StartOP,EndOP");
        httpResponse.EnsureSuccessStatusCode();
        var body = await httpResponse.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<QueryWrapper<IList<SectionOfLine>>>(body)?.Value ?? [];
    }

    private async Task SetToken()
    {
        var httpResponse = await _client.PostAsync(_config.BaseUrl + "/token", new FormUrlEncodedContent(new []
        {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", _config.User),
            new KeyValuePair<string, string>("password", _config.Password)
        }));
        
        httpResponse.EnsureSuccessStatusCode();
        var body = await httpResponse.Content.ReadAsStringAsync();
        var parsedBody = JsonConvert.DeserializeObject<GetTokenResponse>(body);

        if (parsedBody is null || string.IsNullOrWhiteSpace(parsedBody.AccessToken))
        {
            throw new ApplicationException("Token is empty despite successful authentication!");
        }
        
        _authenticated = true;
        _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {parsedBody.AccessToken}");
    }
}
