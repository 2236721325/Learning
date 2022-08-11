using System.Reflection;

namespace 特性
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo()
            {
                Name = "1",
                Number = 1000000000
            };
            var valitor = new Valitor(demo);
        }
    }
    public class Demo
    {
        [HasMaxLength(100)]
        public string Name { get; set; }
        [HasMaxLength(100)]
        public int Number { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class HasMaxLength : Attribute
    {
        public int MaxLength { get; set; }
        public string Name { get; init; }
        public HasMaxLength(int maxLength)
        {
            MaxLength = maxLength;
            Name = nameof(HasMaxLength);
        }
    }

    public class Valitor
    {
        public Valitor(object obj)
        {
            Type t = obj.GetType();
            var attrs = Attribute.GetCustomAttributes(t, typeof(HasMaxLength));
            Console.WriteLine(attrs);
            foreach (PropertyInfo p in t.GetProperties())
            {
                var attr=p.GetCustomAttribute<HasMaxLength>();
                if(attr!=null)
                {
                    Type tp=p.GetType();
                    p.GetValue(obj);
                    
                }
                Console.WriteLine(p);
                Console.WriteLine(p.GetValue(obj));
            }

        }
    }
}