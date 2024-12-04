using Newtonsoft.Json;

namespace Integration.RINF.Models;

public class TAFTAPCodes
{
    [JsonProperty(PropertyName = "Value")]
    public required string PLC { get; set; }
}