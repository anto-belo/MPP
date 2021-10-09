using System;
using System.Reflection;

namespace MPP_8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string assemblyPath = "G:\\Мой диск\\СПП\\MPP\\Test\\bin\\Debug\\Test.exe";
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Console.WriteLine(assembly.FullName);

            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                if (Attribute.GetCustomAttribute(t, typeof(ExportClassAttribute)) != null)
                {
                    Console.WriteLine(t.FullName);
                }
            }
        }
    }
}