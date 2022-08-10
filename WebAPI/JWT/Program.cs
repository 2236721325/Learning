using FluentValidation;
using FluentValidation.AspNetCore;
using JWT.Models;
using JWT.Models.Validators;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

//Ϊ�˷�ֹ�ڲ���Ա��ȡ�û����� Ϊ������ ��Ҫ���û�������Ҫ���� ��MD5����
//FluentValidation ���ŵķ�ʽ��֤���ݣ�ѧ��ѧû��ϵ��EFCORE�Դ����н������Ե���֤
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
            //���Ƽ�ʹ���Զ���֤������˵�ģ�
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