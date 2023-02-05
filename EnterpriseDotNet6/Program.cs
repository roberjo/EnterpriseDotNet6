using EnterpriseDotNet6.API.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;
using Serilog.Formatting.Json;

// Initialize Serilog Settings
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new JsonFormatter())
    .MinimumLevel.Verbose()
    .CreateBootstrapLogger();

Log.Information("Application Starting Up");

try
{

    // Create Builder
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .ReadFrom.Configuration(ctx.Configuration));

    // Add services to the container.

    builder.Services.ConfigureCors();
    builder.Services.ConfigureIISIntegration();
    builder.Services.ConfigureSQLServerContext(builder.Configuration);

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        Log.Fatal("Test Fatal");
        Log.Error("Test Error");
        Log.Warning("Test Warning");
        Log.Information("Test Information");
        Log.Debug("Test Debug");
        Log.Verbose("Test Verbose");
    }
    else
        app.UseHsts();

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    _ = app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });

    app.UseCors("CorsPolicy");

    app.UseAuthorization();
    
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Application shut down complete");
    Log.CloseAndFlush();
}
