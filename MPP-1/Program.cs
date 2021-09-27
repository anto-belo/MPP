using System;
using System.Threading;

namespace MPP_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TaskQueue taskExecutor = new TaskQueue(4);

            for (int i = 1; i <= 20; i++)
            {
                string taskMsg = "Task " + i + " completed";
                taskExecutor.EnqueueTaskDelegate(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(taskMsg);
                });
            }

            while (!taskExecutor.IsReadyToStop())
            {
            }
        }
    }
}