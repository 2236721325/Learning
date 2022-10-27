using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Swashbuckle;
using Autofac.Core;
using Microsoft.OpenApi.Models;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AbpSomeModuleLearns
{
    [DependsOn(typeof(AbpAutofacModule))] // ��ģ�����������AbpAutofacModule
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpSwashbuckleModule))]
    [DependsOn(typeof(AbpAspNetCoreAuthenticationJwtBearerModule))]
    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration=context.Services.GetConfiguration();
            context.Services.AddAbpSwaggerGen(
                   options =>
                   {
                       options.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
                       options.DocInclusionPredicate((docName, description) => true);
                       options.CustomSchemaIds(type => type.FullName);
                   }
               );
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(AppModule).Assembly);
            });
            context.Services.Configure<JWTSettings>(configuration.GetSection("JWT"));//Ҳ������ע�� ע���ʱ�����Ĭ��ֵ��appsettings��ȡ��
            context.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //����JWT�����֤����
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //ʹ��JWT�����֤��ս

            }).AddJwtBearer(option =>
            {
                var jwtSettings =configuration.GetSection("JWT").Get<JWTSettings>();

                byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var secretKey = new SymmetricSecurityKey(keyBytes);
                //��֤���������
                option.TokenValidationParameters = new()
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey
                };

            });
            context.Services.AddAuthorization(options =>
                 options.AddPolicy("Insert",
                 policy => policy.RequireRole("Admin").RequireClaim("Permission","")));

        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseAbpSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API");
                });
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseConfiguredEndpoints();
        }
    }
  
}