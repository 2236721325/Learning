namespace LightAbp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.ReplaceConfiguration(builder.Configuration);//���ڰ汾���µ�ԭ�� .net5û���� �������ǵ�����
            builder.Services.AddApplication<LightAbpModule>();
            builder.Host.UseAutofac();


            var app = builder.Build();
            app.InitializeApplication();


            app.Run();
        }
    }
}