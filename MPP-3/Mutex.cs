using System;
using System.Threading;

namespace MPP_3
{
    public class Mutex
    {
        private int _usedBy;

        public void Lock()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            while (Interlocked.CompareExchange(ref _usedBy, id, 0) != 0)
            {
                Thread.Sleep(10);
            }

            Console.WriteLine("Locked by #" + id);
        }

        public void Unlock()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Interlocked.CompareExchange(ref _usedBy, 0, id);
            Console.WriteLine("Unlocked by #" + id);
        }
    }
}