namespace Integration.RINF.Models;

public class BorderPointModel
{
    public string? Name { get; set; }
    public string? OP1 { get; set; }
    public string? OP2 { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public MemberStateModel? MemberState1 { get; set; }
    public MemberStateModel? MemberState2 { get; set; }
}