using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Swashbuckle;
using Microsoft.OpenApi.Models;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abp从0搭建授权中心.Datas;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Abp从0搭建授权中心
{    
    [DependsOn(typeof(AbpAutofacModule))] // 在模块上添加依赖AbpAutofacModule
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpSwashbuckleModule))] // 在模块上添加依赖AbpAutofacModule
    [DependsOn(typeof(AbpEntityFrameworkCoreMySQLModule))] // 在模块上添加依赖AbpAutofacModule
    [DependsOn(typeof(AbpAspNetCoreAuthenticationJwtBearerModule))] // 在模块上添加依赖AbpAutofacModule

    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            var configuration = context.Services.GetConfiguration();

            //... other configurations.

            services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );

            services.AddAbpDbContext<MyDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });
            services.Configure<JWTSettings>(configuration.GetSection("JWT"));//也是依赖注入 注入的时候带有默认值（appsettings读取）

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //配置JWT身份验证方案
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //使用JWT身份验证挑战

            }).AddJwtBearer(option =>
            {
                var jwtSettings = configuration.GetSection("JWT").Get<JWTSettings>();

                byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var secretKey = new SymmetricSecurityKey(keyBytes);
                //验证的配置添加
                option.TokenValidationParameters = new()
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey
                };

            });
            services.AddAuthorization(options =>
                 options.AddPolicy("Insert",
                 policy => policy.));

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options
                    .ConventionalControllers
                    .Create(typeof(AppModule).Assembly);
            });
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
                //options.Configure(opts =>
                //{
                //    opts.DbContextOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                //});
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
                app.UseAuthentication();//验证是否登录 的中间件
            app.UseAuthorization();//验证用户是否有权限 的中间件

            app.UseConfiguredEndpoints();
        }
    }
}