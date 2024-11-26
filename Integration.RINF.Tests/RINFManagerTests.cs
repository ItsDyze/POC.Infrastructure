using Integration.RINF.Models;
using Microsoft.Extensions.Configuration;

namespace Integration.RINF.Tests;

public class RINFManagerTests
{
    private RINFManager _manager;
    
    [SetUp]
    public void Setup()
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<RINFManagerTests>();
        var config = builder.Build();
        var rinfConfiguration = config.GetSection("RINFConfiguration").Get<RINFConfiguration>() ??
                                throw new ApplicationException("Missing configuration, check your user secrets.");
        _manager = new RINFManager(rinfConfiguration);
    }

    [Test]
    public async Task GetBorderPoints()
    {
        var borderPoints = await _manager.GetBorderPointsAsync();
        
        Assert.That(borderPoints, Is.Not.Null);
        Assert.That(borderPoints, Is.Not.Empty);
        Assert.That(borderPoints[0], Is.InstanceOf<BorderPoint>());
    }
    
    [Test]
    public async Task GetSectionsOfLine()
    {
        var sectionsOfLine = await _manager.GetSectionsOfLineAsync();
        
        Assert.That(sectionsOfLine, Is.Not.Null);
        Assert.That(sectionsOfLine, Is.Not.Empty);
        Assert.That(sectionsOfLine[0], Is.InstanceOf<SectionOfLine>());
    }
    
    [Test]
    public async Task GetOperationalPoints()
    {
        var operationalPoints = await _manager.GetOperationalPointsAsync();
        
        Assert.That(operationalPoints, Is.Not.Null);
        Assert.That(operationalPoints, Is.Not.Empty);
        Assert.That(operationalPoints[0], Is.InstanceOf<OperationalPoint>());
    }
}
