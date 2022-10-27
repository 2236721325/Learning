using Autofac;

namespace AutofacModule
{
    public interface IService
    {
        void SayOk();

    }
    public class Service : IService
    {
        public void SayOk()
        {
            Console.WriteLine("Ok");
        }
    }
    public class TestModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Service>().As<IService>().SingleInstance();
        }
    }

}