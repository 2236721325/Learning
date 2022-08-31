namespace LightAbp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.ReplaceConfiguration(builder.Configuration);//由于版本更新的原因 .net5没问题 不是我们的问题
            builder.Services.AddApplication<LightAbpModule>();
            builder.Host.UseAutofac();


            var app = builder.Build();
            app.InitializeApplication();


            app.Run();
        }
    }
}