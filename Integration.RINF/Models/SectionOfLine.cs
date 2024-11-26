namespace Integration.RINF.Models;

public class SectionOfLine
{
    public required string SOLName { get; set; }
    public required string Country { get; set; }
    public required decimal Length { get; set; }
    public required DateTime? ValidityDateStart { get; set; }
    public required DateTime? ValidityDateEnd { get; set; }
    public required OperationalPoint StartOP { get; set; }
    public required OperationalPoint EndOP { get; set; }
}
