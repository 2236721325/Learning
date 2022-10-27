namespace AutoFacDemo
{
    public class TestService : ITestService
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
    public interface ITestService
    {
        void SayHello();
    }
}