using Integration.RINF.Entities;
using Integration.RINF.Interfaces;
using Integration.RINF.Models;
using MongoDB.Driver.Linq;

namespace Integration.RINF.Services;

public class OperationalPointsService : IOperationalPointsService
{
    private readonly IntegrationDbContext _db;
    
    public OperationalPointsService(IntegrationDbContext dbContext)
    {
        _db = dbContext;
    }
    
    public async Task<IList<OperationalPoint>> GetOperationalPoints()
    {
        return await _db.OperationalPoints.ToListAsync();
    }
}