using HaalCentraal.Generated.DataService;
using Microsoft.AspNetCore.Mvc;

namespace Historie.Data.Mock.Extensions;

public static class InvalidModelStateResponseFactory
{
    public static IMvcBuilder ConfigureInvalidModelStateHandling(this IMvcBuilder builder)
    {
        return builder.ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context => CreateProblemDetails(context);
        });
    }

    private static IActionResult CreateProblemDetails(ActionContext context)
    {
        var invalidParams = (from kvp in context.ModelState
                             from error in kvp.Value.Errors
                             let errorCode = error.ErrorMessage.ParseErrorCode()
                             let errorReason = error.ErrorMessage.ParseErrorReason()
                             select new InvalidParams
                             {
                                 Name = $"{char.ToLowerInvariant(kvp.Key[0])}{kvp.Key[1..]}",
                                 Code = errorCode,
                                 Reason = errorReason
                             }).ToList();
        var titel = "Een of meerdere parameters zijn niet correct.";
        var code = "paramsValidation";
        var foutbericht = new BadRequestFoutbericht
        {
            Instance = new Uri(context.HttpContext.Request.Path, UriKind.Relative),
            Status = StatusCodes.Status400BadRequest,
            Title = titel,
            Type = new Uri("https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"),
            Code = code,
            InvalidParams = invalidParams,
            Detail = $"De foutieve parameter(s) zijn: {string.Join(", ", invalidParams.Select(x => x.Name))}."
        };

        return new BadRequestObjectResult(foutbericht)
        {
            ContentTypes = { "application/problem+json" }
        };
    }

    private static string? ParseErrorCode(this string errorMessage) =>
        errorMessage != null && errorMessage.Contains("||")
            ? errorMessage.Split("||")[0]
            : null;

    private static string? ParseErrorReason(this string errorMessage) =>
        errorMessage != null && errorMessage.Contains("||")
            ? errorMessage.Split("||")[1]
            : errorMessage;
}
