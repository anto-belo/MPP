using System;
using System.Threading;

namespace MPP_7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tasks = CreateTasks();
            Parallel.WaitAll(tasks);
        }

        private static WaitCallback[] CreateTasks()
        {
            WaitCallback[] tasks = new WaitCallback[200];
            for (var i = 0; i < tasks.Length; i++)
            {
                int index = i;
                tasks[i] = _ =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Task {index} completed.");
                };
            }

            return tasks;
        }
    }
}