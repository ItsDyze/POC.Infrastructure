using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Integration.RINF.Contracts;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetTokenResponse
{
    public string? AccessToken { get; set; }
    public string? TokenType { get; set; }
    public int ExpiresIn { get; set; }
}