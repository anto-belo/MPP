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
                        Thread.Sleep(400);
                        m.Unlock();
                    }
                ).Start();
            }
        }
    }
}