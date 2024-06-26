using AutoMapper;
using Brp.Shared.Infrastructure.Http;
using Brp.Shared.Infrastructure.Stream;
using Brp.Shared.Infrastructure.Validatie;
using Historie.Informatie.Service.Helpers;
using Serilog;

namespace Historie.Informatie.Service.Middlewares;

public class OverwriteResponseBodyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMapper _mapper;
    private readonly IDiagnosticContext _diagnosticContext;

    public OverwriteResponseBodyMiddleware(RequestDelegate next, IMapper mapper, IDiagnosticContext diagnosticContext)
    {
        _next = next;
        _mapper = mapper;
        _diagnosticContext = diagnosticContext;
    }

    public async Task Invoke(HttpContext context)
    {
        var orgBodyStream = context.Response.Body;

        using var newBodyStream = new MemoryStream();
        context.Response.Body = newBodyStream;

        await _next(context);

        if (!await context.HandleNotFound())
        {
            return;
        }
        if (!await context.HandleServiceIsAvailable())
        {
            return;
        }

        var body = await context.Response.ReadBodyAsync();

        if (Log.IsEnabled(Serilog.Events.LogEventLevel.Debug))
        {
            _diagnosticContext.Set("original response headers", context.Response.Headers);
            _diagnosticContext.Set("original response body", Newtonsoft.Json.Linq.JObject.Parse(body), true);
        }

        var modifiedBody = context.Response.StatusCode == StatusCodes.Status200OK
            ? body.Transform(_mapper)
            : body;

        if (Log.IsEnabled(Serilog.Events.LogEventLevel.Debug))
        {
            _diagnosticContext.Set("modified response body", Newtonsoft.Json.Linq.JObject.Parse(modifiedBody), true);
        }

        using var bodyStream = modifiedBody.ToMemoryStream(context.Response.UseGzip());

        context.Response.ContentLength = bodyStream.Length;
        await bodyStream.CopyToAsync(orgBodyStream);
    }
}
