using System;
using System.Threading;

namespace MPP_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Mutex m = new Mutex();
            for (int i = 0; i < 5; i++)
            {
                new Thread(() =>
                    {
                        m.Lock();
                        Console.WriteLine("Locked by #" + Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1000);
                        m.Unlock();
                        Console.WriteLine("Unlocked by #" + Thread.CurrentThread.ManagedThreadId);

                    }
                ).Start();
            }
        }
    }
}