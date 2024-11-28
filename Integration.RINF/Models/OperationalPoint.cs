using Newtonsoft.Json;

namespace Integration.RINF.Models;

public class OperationalPoint
{
    public required int ID { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Country { get; set; }
    public required decimal Latitude { get; set; }
    public required decimal Longitude { get; set; }
    public required string UOPID { get; set; }
    
    [JsonProperty(PropertyName = "TafTAPCodes")]
    public required List<TAFTAPCodes> PLCs { get; set; }
    
}