using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FunctionCache<string, int> cache = new FunctionCache<string, int>();
            string inputKey = "example";

            int result1 = cache.Execute(GetValue, inputKey, TimeSpan.FromSeconds(5));
            Console.WriteLine($"Result 1: {result1}");

            int result2 = cache.Execute(GetValue, inputKey, TimeSpan.FromSeconds(5));
            Console.WriteLine($"Result 2: {result2}");

            System.Threading.Thread.Sleep(6000);

            int result3 = cache.Execute(GetValue, inputKey, TimeSpan.FromSeconds(5));
            Console.WriteLine($"Result 3: {result3}");
        }

        static int GetValue(string key)
        {
            Console.WriteLine("Executing function to get value...");
            return key.GetHashCode();
        }
    }
    }
}
