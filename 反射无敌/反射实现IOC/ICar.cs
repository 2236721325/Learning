namespace 反射实现IOC
{
    //Car 依赖 Money
    public interface ICar
    {
        IMoney IMoney { get; set; }
        void Run();
    }

}