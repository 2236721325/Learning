using Microsoft.OpenApi.Models;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp;
using AbpDDDLearn.EntityFrameworkCore;
using AbpDDDLearn.Application;

namespace AbpDDDLearn.HttpApi.Host
{
    [DependsOn(
     typeof(AbpAutofacModule),
     typeof(AbpDDDLearnApplicationModule),
     typeof(AbpDDDLearnEntityFrameworkCoreModule),
     typeof(AbpSwashbuckleModule),
     typeof(AbpAspNetCoreMvcModule)
)]
    public class AbpDDDLearnHttpApiHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            ConfigureSwaggerGen(context);
            ConfigureConventionalControllers();
        }

        private void ConfigureSwaggerGen(ServiceConfigurationContext context)
        {
            context.Services.AddAbpSwaggerGen(
                  options =>
                  {
                      options.SwaggerDoc("v1", new OpenApiInfo { Title = "AbpDDDLearn", Version = "v1" });
                      options.DocInclusionPredicate((docName, description) => true);
                  }
              );
        }

        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(AbpDDDLearnApplicationModule).Assembly);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AbpDDDLearn");
            });
            app.UseRouting();
            app.UseStaticFiles();
            app.UseConfiguredEndpoints();
        }
      
    }
}