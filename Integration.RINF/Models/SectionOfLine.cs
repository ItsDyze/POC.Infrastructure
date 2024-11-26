namespace Integration.RINF.Models;

public class SectionOfLine
{
    public string SOLName { get; set; }
    public string Country { get; set; }
    public decimal Length { get; set; }
    public DateTime? ValidityDateStart { get; set; }
    public DateTime? ValidityDateEnd { get; set; }
    public OperationalPoint StartOP { get; set; }
    public OperationalPoint EndOP { get; set; }
}