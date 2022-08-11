using System.Linq;

namespace Linq
{
  
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo_Join();
        }
        static void Demo_Join()
        {
            int[] nums1 = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] nums2 = new int[] { 2, 5, 35, 45, 56, 66 };
            var c=nums1.Join<int, int, int,dynamic>(nums2, p => p, q => q, (p, q) => new 
            {
                first = p,
                second = q
            });

            foreach (var item in c)
            {
                Console.WriteLine(item);
            }

        }
        static void Demo_Chunk()
        {
            int chunkNumber = 1;

            var longEnumerable = Enumerable.Range(0, 7);

            foreach (int[] chunk in longEnumerable.Chunk(3))
            {
                Console.WriteLine($"Chunk {chunkNumber++}");
                foreach (var item in chunk)
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void Demo_GroupBy()
        {
            string[] anagrams = { "from   "," salt", " earn ", "  last   ", " nears ", " form  ","from" };

            var orderGroups = anagrams.GroupBy(k=>k.Trim().Length,r=>r.Trim());

            foreach (var s in orderGroups)
            {
                Console.WriteLine("--------------");
                foreach (var i in s.ToList())
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Demo_FirstOrDefault()
        {
            int[] numbers = { };

            int firstNumOrDefault = numbers.FirstOrDefault();

            Console.WriteLine(firstNumOrDefault);

            object[] objs = { };
            var o = objs.FirstOrDefault();

            Console.WriteLine(o);

        }
        static void Demo_OfType()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            var doubles = numbers.OfType<double>();

            Console.WriteLine("Numbers stored as doubles:");
            foreach (var d in doubles)
            {
                Console.WriteLine(d);
            }
        }
    }

}