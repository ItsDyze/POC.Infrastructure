using Integration.RINF.Controllers;
using Integration.RINF.Entities;
using Integration.RINF.Interfaces;
using Integration.RINF.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder().AddUserSecrets<Program>();
var config = configBuilder.Build();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IntegrationDbContext>(options => options.UseMongoDB(builder.Configuration["MongoDB:ConnectionString"] ?? throw new Exception("Check docker compose"), builder.Configuration["MongoDB:DatabaseName"] ?? throw new Exception("Check docker compose")));

builder.Services.AddSingleton<IRINFService, RINFService>();
builder.Services.AddSingleton<IOperationalPointsService, OperationalPointsService>();
builder.Services.AddSingleton(config.GetSection("RINFConfiguration").Get<RINFConfiguration>() ??
                              throw new ApplicationException("Missing configuration, check your user secrets."));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        corsBuilder =>
        {
            corsBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();
app.MapOperationalPointsEndpoints();

app.Run();