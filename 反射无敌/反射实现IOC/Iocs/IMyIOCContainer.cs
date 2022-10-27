namespace 反射实现IOC.Iocs
{
    public interface IMyIOCContainer
    {
        void ResolveType<TFrom, TTo>();
        T Resolve<T>();
    }
}
