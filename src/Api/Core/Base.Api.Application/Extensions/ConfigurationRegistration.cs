using Base.Api.Application.Features.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Base.Api.Application.Extensions;

public static class ConfigurationRegistration
{
    public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
    {
        // Adding HealthCheck endpoint for monitoring
        app.UseHealthChecks("/api/health", new HealthCheckOptions()
        {
            ResponseWriter = async (context, report) =>
            {
                await context.Response.WriteAsync("OK");
            }
        });

        return app;
    }


    public static IApplicationBuilder UseCustomMiddleWares(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        return app;
    }


}
