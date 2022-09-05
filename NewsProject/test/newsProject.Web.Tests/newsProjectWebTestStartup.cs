using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace newsProject;

public class newsProjectWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<newsProjectWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
