using Integration.RINF.Interfaces;
using Integration.RINF.Models;

namespace Integration.RINF.Services;

public class OperationalPointsService : IOperationalPointsService
{
    public async Task<IList<OperationalPoint>> GetOperationalPoints()
    {
        return await Task.Run(() => new List<OperationalPoint>());
    }
}