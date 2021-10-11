using System;

namespace MPP_9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DynamicList<string> strings = new DynamicList<string>(5, 0.75);
            strings.Add("Test 1");
            strings.Add("Test 2");
            strings.Add("Test 51");
            foreach (var s in strings)
            {
                Console.Write(s + " ");
            }

            Console.WriteLine();
            Console.WriteLine($"{strings.Count} / {strings.Capacity}");
            strings.Add("Test 4");
            Console.WriteLine(strings);
            Console.WriteLine($"{strings.Count} / {strings.Capacity}");
            strings.Remove("Test 51");
            Console.WriteLine(strings);
            Console.WriteLine($"{strings.Count} / {strings.Capacity}");
            strings.RemoveAt(1);
            Console.WriteLine(strings);
            Console.WriteLine($"{strings.Count} / {strings.Capacity}");
            strings.Clear();
            Console.WriteLine(strings);
            Console.WriteLine($"{strings.Count} / {strings.Capacity}");
        }
    }
}