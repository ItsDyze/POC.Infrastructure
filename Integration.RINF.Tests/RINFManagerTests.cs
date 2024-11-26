using Integration.RINF.Models;
using NuGet.Frameworks;

namespace Integration.RINF.Tests;

public class RINFManagerTests
{
    private RINFConfiguration _configuration;
    private RINFManager _manager;
    
    [SetUp]
    public void Setup()
    {
        _configuration = new RINFConfiguration(
            Environment.GetEnvironmentVariable("RINF_User"),
            Environment.GetEnvironmentVariable("RINF_Password"),
            Environment.GetEnvironmentVariable("RINF_BaseUrl")
        );
        
        _manager = new RINFManager(_configuration);
    }

    [Test]
    public async Task GetBorderPoints()
    {
        var borderPoints = await _manager.GetBorderPointsAsync();
        
        Assert.IsNotNull(borderPoints);
        Assert.IsNotEmpty(borderPoints);
        Assert.IsTrue(borderPoints.FirstOrDefault() is BorderPoint);
    }
    
    [Test]
    public async Task GetSectionsOfLine()
    {
        var sectionsOfLine = await _manager.GetSectionsOfLineAsync();
        
        Assert.IsNotNull(sectionsOfLine);
        Assert.IsNotEmpty(sectionsOfLine);
        Assert.IsTrue(sectionsOfLine.FirstOrDefault() is SectionOfLine);
    }
    
    [Test]
    public async Task GetOperationalPoints()
    {
        var operationalPoints = await _manager.GetOperationalPointsAsync();
        
        Assert.IsNotNull(operationalPoints);
        Assert.IsNotEmpty(operationalPoints);
        Assert.IsTrue(operationalPoints.FirstOrDefault() is OperationalPoint);
    }
}