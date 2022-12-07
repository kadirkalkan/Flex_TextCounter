using Microsoft.AspNetCore.Builder;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Api.Application.Extensions;

public static class BuilderHostRegistration
{
    public static ConfigureHostBuilder UseCustomSerilog(this ConfigureHostBuilder host)
    {
        host.UseSerilog((context, logger) =>
        {
            logger.WriteTo.Debug(Serilog.Events.LogEventLevel.Error)
                  .WriteTo.File(@"Log\ErrorLog.txt", Serilog.Events.LogEventLevel.Error);
        });

        return host;
    }
}
