using Base.Common.Infrastructure.Exceptions;
using Base.Common.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Api.Application.Features.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (CustomException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        } 
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var message = exception switch
        {
            CustomException => exception.Message,
            _ => "Internal Server Error."
        };

        var exceptionResponse = new ExceptionResponse()
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            ExceptionMessage = message,
            Route = context.Request.Path
        };

        _logger.LogError($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} => {exceptionResponse}");

        await context.Response.WriteAsync(exceptionResponse.ToString());
    }
}
