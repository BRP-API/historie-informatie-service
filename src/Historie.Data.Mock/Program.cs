using Brp.Shared.Infrastructure.Logging;
using Brp.Shared.Infrastructure.Utils;
using Brp.Shared.Validatie;
using Brp.Shared.Validatie.Middleware;
using Historie.Data.Mock.Repositories;
using Historie.Informatie.Service.Middlewares;
using Serilog;

Log.Logger = SerilogHelpers.SetupSerilogBootstrapLogger();

try
{
    Log.Information("Starting {AppName} v{AppVersion}. TimeZone: {TimeZone}. Now: {TimeNow}",
                    AssemblyHelpers.Name, AssemblyHelpers.Version, TimeZoneInfo.Local.StandardName, DateTime.Now);

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHttpContextAccessor();

    builder.SetupSerilog(Log.Logger);

    builder.SetupVerblijfplaatshistorieRequestValidation();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddScoped<PersoonRepository>();

    builder.Services.AddControllers()
                    .AddNewtonsoftJson();

    var app = builder.Build();

    app.UseMiddleware<RequestValidatieMiddleware>();

    app.UseMiddleware<OverwriteResponseBodyMiddleware>();

    app.MapControllers();

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "{AppName} terminated unexpectedly", AssemblyHelpers.Name);
}
finally
{
    await Log.CloseAndFlushAsync();
}