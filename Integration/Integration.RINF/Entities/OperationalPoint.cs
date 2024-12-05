namespace Integration.RINF.Entities;

public class OperationalPoint
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Country { get; set; }
    public required decimal Latitude { get; set; }
    public required decimal Longitude { get; set; }
    public required string UOPID { get; set; }
    public required string PLC { get; set; }
}