using FluentValidation;
using FluentValidation.AspNetCore;
using JWT.Models;
using JWT.Models.Validators;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

//为了防止内部人员窃取用户密码 为非作歹 需要对用户密码需要加密 用MD5加密
//FluentValidation 优雅的方式验证数据（学不学没关系）EFCORE自带的有借助特性的验证
namespace JWT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //不推荐使用自动验证（官网说的）
            builder.Services.AddScoped<IValidator<UserInfo>, UserInfoValidator>();



            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(
                 builder.Configuration.GetConnectionString("DefaultConnection")
                 ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}