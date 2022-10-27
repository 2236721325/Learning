using Dto_autemapper_redis.Commoms.GuidGenerator;
using Dto_autemapper_redis.Datas;
using Dto_autemapper_redis.ObjectMappers;
using Microsoft.EntityFrameworkCore;

namespace Dto_autemapper_redis
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

            //������ݿ�mysql
            builder.Services.AddDbContextPool<MyDbContext>(options=>
            {
                var connectionStr = builder.Configuration.GetConnectionString("Default");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                var version = ServerVersion.AutoDetect(connectionStr);
                options.UseMySql(connectionStr,version);
            });

            //����Guid����
            //���������������� �ɺ��ԡ�
            builder.Services.AddSingleton<IGuidGenerator, SequentialGuidGenerator>();

            builder.Services.Configure<AbpSequentialGuidGeneratorOptions>(options =>
            {
                options.DefaultSequentialGuidType = SequentialGuidType.SequentialAsString;//MySql�����
            });

            //AutoMapper����
            builder.Services.AddAutoMapper(typeof(CustomProfile));


            //����ڴ滺��
            builder.Services.AddMemoryCache();
            //�ֲ�ʽ����ʹ��Redis
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("MyRedisConStr");
                options.InstanceName = "Demo";
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}