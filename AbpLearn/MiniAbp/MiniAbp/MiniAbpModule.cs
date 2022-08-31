using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp;
using Volo.Abp.Autofac;
using Autofac.Core;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.MultiTenancy;

namespace MiniAbp
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    public class MiniAbpModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            base.ConfigureServices(context);
            context.Services.AddControllers();
            ConfigureAutoApi(context);

            context.Services.AddSwaggerGen(
               options =>
               {
                   options.SwaggerDoc("v1", new OpenApiInfo { Title = "MiniAPI", Version = "v1" });
                   options.DocInclusionPredicate((docName, description) => true);
                   options.CustomSchemaIds(type => type.FullName);
               });


        }
        private void ConfigureAutoApi(ServiceConfigurationContext context)
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options
                    .ConventionalControllers
                    .Create(typeof(MiniAbpModule).Assembly);
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

         
            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();

       

            app.UseUnitOfWork();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SingelAbp API");
            });

            app.UseAuditing();
            app.UseConfiguredEndpoints();
        }
    }
}
