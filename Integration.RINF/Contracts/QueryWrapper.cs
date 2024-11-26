using Newtonsoft.Json;

namespace Integration.RINF.Contracts;

public class QueryWrapper<T>
{
    [JsonProperty("@odata.context")]
    public string? Context { get; set; }
    public T? Value { get; set; }
}