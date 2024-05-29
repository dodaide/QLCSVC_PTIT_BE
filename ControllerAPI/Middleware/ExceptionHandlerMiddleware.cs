using System.Net;
using Domain.Entities;

namespace Controller.Middleware;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            BaseException response;
            switch (ex)
            {
                case ValidateException:
                    var tempEx = ex as ValidateException;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new BaseException
                    {
                        ErrorCode = context.Response.StatusCode,
                        DevMessage = ex.Message,
                        UserMessage = ex.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = ex.HelpLink ?? "https://www.facebook.com/",
                        Errors = tempEx.Errors
                    };
                    break;
                default:
                    _logger.LogError(ex, ex.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = new BaseException
                    {
                        ErrorCode = context.Response.StatusCode,
#if DEBUG
                        DevMessage = ex.Message,
#else
                            DevMessage = "",
#endif
                        UserMessage = "",
                        MoreInfo = ex.HelpLink ?? "https://www.facebook.com/",
                        TraceId = context.TraceIdentifier
                    };
                    break;
            }

            await WriteResponseAsync(context, response);
        }
    }

    private static async Task WriteResponseAsync(HttpContext context, BaseException response)
    {
        context.Response.ContentType = "application/json";
        var json = response.ToString();
        await context.Response.WriteAsync(json);
    }
}