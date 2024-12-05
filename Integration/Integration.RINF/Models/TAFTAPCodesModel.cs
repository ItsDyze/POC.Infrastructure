using Newtonsoft.Json;

namespace Integration.RINF.Models;

public class TAFTAPCodesModel
{
    [JsonProperty(PropertyName = "Value")]
    public required string PLC { get; set; }
}