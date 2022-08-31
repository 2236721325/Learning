using LightAbp.Datas;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace LightAbp
{
    public class MyOptions
    {
        public int Value1 { get; set; }
        public bool Value2 { get; set; }
    }
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAutoMapperModule)

        )]
    public class LightAbpModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureAutoApi(context);
            ConfigureEfCore(context);
            ConfigureSwagger(context.Services);

            Configure<AbpAutoMapperOptions>(options =>
            {
                //Add all mappings defined in the assembly of the MyModule class
                options.AddMaps<LightAbpModule>();
            });


        }

        private void ConfigureEfCore(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MyDbContext>(options =>
            {

                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(configurationContext =>
                {
                    configurationContext.UseSqlServer();
                });
            });
        }
        private void ConfigureAutoApi(ServiceConfigurationContext context)
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options
                    .ConventionalControllers
                    .Create(typeof(LightAbpModule).Assembly);
            });
        }
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {   // Add services to the container.
            // Configure the HTTP request pipeline.

            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // Configure the HTTP request pipeline.
            //if (env.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My");
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        


        }

    }
}
