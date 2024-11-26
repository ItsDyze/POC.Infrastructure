using Integration.RINF.Models;

namespace Integration.RINF.Interfaces;

public interface IRINFManager
{
    public Task<IList<BorderPoint>> GetBorderPointsAsync();
    public Task<IList<OperationalPoint>> GetOperationalPointsAsync();
    public Task<IList<SectionOfLine>> GetSectionsOfLineAsync();
}
