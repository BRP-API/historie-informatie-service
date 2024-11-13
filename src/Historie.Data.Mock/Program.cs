using Brp.Shared.Infrastructure.Logging;
using Brp.Shared.Infrastructure.Utils;
using Historie.Data.Mock.Extensions;
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

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddScoped<PersoonRepository>();

    builder.Services.AddControllers()
                    .ConfigureInvalidModelStateHandling()
                    .AddNewtonsoftJson();

    var app = builder.Build();

    app.UseMiddleware<OverwriteResponseBodyMiddleware>();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "{AppName} terminated unexpectedly", AssemblyHelpers.Name);
}
finally
{
    Log.CloseAndFlush();
}