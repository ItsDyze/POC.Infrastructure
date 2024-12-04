namespace Integration.RINF.Services;

public class RINFConfiguration(string user, string password, string baseUrl, string? tempStorage = null)
{
    public string User { get; } = user;
    public string Password { get; } = password;
    public string BaseUrl { get; } = baseUrl;
    
    public string? TempStorage { get; } = tempStorage;
}