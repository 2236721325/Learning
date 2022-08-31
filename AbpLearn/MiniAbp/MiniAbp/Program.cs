
namespace MiniAbp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseAutofac();  //Add this line

        builder.Services.ReplaceConfiguration(builder.Configuration);


        builder.Services.AddApplication<MiniAbpModule>();

        var app = builder.Build();

        app.InitializeApplication();

        app.Run();


        ////builder.Services.AddEndpointsApiExplorer();
        ////builder.Services.AddSwaggerGen();

        //var app = builder.Build();

        //    // Configure the HTTP request pipeline.
        //    if (app.Environment.IsDevelopment())
        //    {
        //        app.UseSwagger();
        //        app.UseSwaggerUI();
        //    }

        //    app.UseAuthorization();


        //    app.MapControllers();

        //    app.Run();
        //}
    }
}