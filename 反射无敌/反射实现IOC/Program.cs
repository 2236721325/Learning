using System;
using System.Reflection;
using 反射实现IOC.Iocs;

namespace 反射实现IOC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMyIOCContainer myIOC = new MyIOCContainer();
            myIOC.ResolveType<ICar, Car>();
            myIOC.ResolveType<IMoney, Money>();
            ICar car = myIOC.Resolve<ICar>();
            car.Run();


            Console.ReadKey();

        }
        static void test(Type type)
        {
            Console.WriteLine(type.FullName);
            assembly.GetType(type.FullName);
        }
    }
}
