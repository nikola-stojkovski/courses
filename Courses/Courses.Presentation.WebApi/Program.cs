using Courses.Core.Application;
using Courses.Core.Contracts;
using Courses.Infrastructure.Persistence;
using Courses.Infrastructure.Persistence.Seed;
using Courses.Presentation.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Register Layers
builder.Services.AddContracts();
builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);
#endregion

#region API Versioning
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});
#endregion

var app = builder.Build();

#region Seeding Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var _dataSeeder = services.GetRequiredService<IDataSeeder>();

    try
    {
        _dataSeeder.SeedData();
    }
    catch (Exception ex)
    {
        throw;
    }
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

ErrorHandlerMiddlewareExtensions.UseErrorHandlerMiddleware(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
