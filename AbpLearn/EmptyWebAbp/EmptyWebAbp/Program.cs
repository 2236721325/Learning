namespace EmptyWebAbp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseAutofac();  //Add this line



            builder.Services.ReplaceConfiguration(builder.Configuration);
           
            builder.Services.AddApplication<AppModule>();


            var app = builder.Build();

            app.InitializeApplication();

            app.Run();

        }
    }
}