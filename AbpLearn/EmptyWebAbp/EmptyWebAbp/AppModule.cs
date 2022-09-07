using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Swashbuckle;
using Microsoft.OpenApi.Models;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmptyWebAbp.Datas;
using Volo.Abp.AutoMapper;
using Volo.Abp.Guids;
using Volo.Abp.Caching;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.RabbitMQ;
using Volo.Abp.Caching.StackExchangeRedis;
using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace EmptyWebAbp
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))] // 在模块上添加依赖AbpAutofacModule
    [DependsOn(typeof(AbpSwashbuckleModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreSqlServerModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpCachingModule))]
    [DependsOn(typeof(AbpCachingStackExchangeRedisModule))]
    [DependsOn(typeof(AbpEventBusRabbitMqModule))]

    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpSwaggerGen(options => 
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });


            context.Services.AddAbpDbContext<MyDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });
            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(opts =>
                {
                    opts.DbContextOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    opts.UseSqlServer();
                });
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                //Add all mappings defined in the assembly of the MyModule class
                options.AddMaps<AppModule>();
            });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options
                    .ConventionalControllers
                    .Create(typeof(AppModule).Assembly);
            });
            Configure<AbpSequentialGuidGeneratorOptions>(options =>
            {
                options.DefaultSequentialGuidType = SequentialGuidType.SequentialAtEnd;
            });
            Configure<AbpRabbitMqOptions>(options =>
            {
                options.Connections.Default.UserName = "guest";
                options.Connections.Default.Password = "guest";
                options.Connections.Default.HostName = "43.142.56.188";
                options.Connections.Default.Port = 5672;
            });
            Configure<AbpRabbitMqEventBusOptions>(options =>
            {
                options.ClientName = "EmptyWebAbp";
                options.ExchangeName = "EmptyWebAbpMessage";
            });
          
            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.KeyPrefix = "EmptyWebAbp";
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseAbpSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API");
                });
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}