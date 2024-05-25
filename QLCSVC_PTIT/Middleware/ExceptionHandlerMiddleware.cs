﻿using Domain.Entities;
using System.Net;

namespace API.Middleware
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        readonly ILogger<ExceptionHandlerMiddleware> _logger;
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
                        ValidateException? tempEx = ex as ValidateException;
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response = new BaseException
                        {
                            ErrorCode = context.Response.StatusCode,
                            DevMessage = ex.Message,
                            UserMessage = ex.Message,
                            TraceId = context.TraceIdentifier,
                            MoreInfo = ex.HelpLink ?? "https://www.facebook.com/dodaide2002/",
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
                            MoreInfo = ex.HelpLink ?? "https://www.facebook.com/dodaide2002/",
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
            string json = response.ToString();
            await context.Response.WriteAsync(json);
        }
    }
}
