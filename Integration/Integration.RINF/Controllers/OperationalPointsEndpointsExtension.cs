using Integration.RINF.Interfaces;

namespace Integration.RINF.Controllers;

public static class OperationalPointsEndpointsExtension
{
    public static void MapOperationalPointsEndpoints(this WebApplication app)
    {
        var _service = app.Services.GetService<IOperationalPointsService>(); 
        
        app.MapGet("/operational-points", () => { return _service.GetOperationalPoints(); })
            .WithName("GetOperationalPoints")
            .WithOpenApi();
    }
}