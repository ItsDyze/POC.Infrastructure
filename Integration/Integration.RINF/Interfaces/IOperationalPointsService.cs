using Integration.RINF.Entities;
using Integration.RINF.Models;

namespace Integration.RINF.Interfaces;

public interface IOperationalPointsService
{
    Task<IList<OperationalPoint>> GetOperationalPoints();
}