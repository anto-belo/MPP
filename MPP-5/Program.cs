using System;
using System.Reflection;

namespace MPP_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string assemblyPath = "G:\\Мой диск\\СПП\\MPP\\Test\\bin\\Debug\\Test.exe";
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Console.WriteLine(assembly.FullName);

            Type[] types = assembly.GetTypes();
            Array.Sort(types, (a, b)
                => string.Compare(a.FullName, b.FullName, StringComparison.Ordinal));
            foreach (Type t in types)
            {
                if (t.IsPublic)
                {
                    Console.WriteLine(t.FullName);
                }
            }
        }
    }
}