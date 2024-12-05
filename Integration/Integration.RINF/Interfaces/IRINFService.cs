using Integration.RINF.Models;

namespace Integration.RINF.Interfaces;

public interface IRINFService
{
    public Task<IList<BorderPointModel>> GetBorderPointsAsync();
    public Task<IList<OperationalPointModel>> GetOperationalPointsAsync();
    public Task<IList<SectionOfLineModel>> GetSectionsOfLineAsync();
}
