using Integration.RINF.Models;

namespace Integration.RINF.Interfaces;

public interface IRINFManager
{
    public Task<IEnumerable<BorderPoint>> GetBorderPointsAsync();
    public Task<IEnumerable<OperationalPoint>> GetOperationalPointsAsync();
    public Task<IEnumerable<SectionOfLine>> GetSectionsOfLineAsync();
}