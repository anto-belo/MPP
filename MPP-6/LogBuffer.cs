using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MPP_6
{
    public class LogBuffer
    {
        private const int MsgLimit = 5;
        private const int TimeLimit = 10;

        private StreamWriter _writer;
        private int _timer;
        private bool _stop;
        private readonly Queue<string> _buffer;
        private readonly object _locker = new();

        public LogBuffer()
        {
            _buffer = new Queue<string>();
        }

        public void Start()
        {
            _writer = new StreamWriter("log.txt", true);
            new Thread(Listener).Start();
            while (!_stop)
            {
                Console.Write("Input message: ");
                string log = Console.ReadLine();
                if (log == "/stop")
                {
                    _stop = true;
                }
                else
                {
                    Add(log);
                }
            }

            Console.WriteLine("Logger stopped");
            Flush();
            _writer.Close();
        }

        private async void Add(string item)
        {
            _buffer.Enqueue(item);
            _timer = 0;
            if (_buffer.Count >= MsgLimit)
            {
                await Task.Run(Flush);
            }
        }

        private void Flush()
        {
            lock (_locker)
            {
                Console.WriteLine("FLUSH");
                int logCount = _buffer.Count;
                for (int i = 0; i < logCount; i++)
                {
                    _writer.WriteLine(_buffer.Dequeue());
                }

                _writer.Flush();
            }
        }

        private void Listener()
        {
            while (!_stop)
            {
                _timer++;
                if (_timer == TimeLimit)
                {
                    Flush();
                    _timer = 0;
                }

                Thread.Sleep(1000);
            }
        }
    }
}