using Newtonsoft.Json;

namespace Integration.RINF.Models;

public class OperationalPointModel
{
    public required int ID { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Country { get; set; }
    public required decimal Latitude { get; set; }
    public required decimal Longitude { get; set; }
    public required string UOPID { get; set; }
    
    [JsonProperty(PropertyName = "TafTAPCodes")]
    public required List<TAFTAPCodesModel> PLCs { get; set; }
    
}