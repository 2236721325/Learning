using API_Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Secord_API.DbContexts;
using Secord_API.Models;
using Secord_API.Repositorys;

namespace Secord_API
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
            builder.Services.AddDbContext<SecondDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddUnitOfWork<SecondDbContext>()
                .AddCustomRepository<SecondEntity, SecondEntityRepository>();

            builder.Services.AddCap(config =>
            {
                config.UseRabbitMQ("localhost");
                config.UseEntityFramework<SecondDbContext>();
            });

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