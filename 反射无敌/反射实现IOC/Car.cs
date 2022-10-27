namespace 反射实现IOC
{
    public class Car : ICar
    {
        public IMoney IMoney { get; set; }
        public Car(IMoney money)
        {
            this.IMoney = money;
            Console.WriteLine("Car已被构造！");
        }

        public void Run()
        {
            IMoney.Say();
        }
    }

}