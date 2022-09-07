using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace LearnAbp;

public class LearnAbpWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<LearnAbpWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
