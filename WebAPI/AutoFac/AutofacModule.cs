using Autofac;
using System.Runtime.InteropServices;

namespace AutoFacDemo
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestService>().As<ITestService>().SingleInstance();
        }
    }
}