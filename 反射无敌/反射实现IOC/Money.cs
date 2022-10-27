namespace 反射实现IOC
{
    public class Money : IMoney
    {
        public bool IsSoMuch { get; set; }
        public Money()
        {
            Console.WriteLine("Money已被构造！！！");
        }
        public void Say()
        {
            Console.WriteLine("Say");
        }
    }

}