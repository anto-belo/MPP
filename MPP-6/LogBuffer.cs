using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MPP_6
{
    public class LogBuffer
    {
        private const int MsgLimit = 5;
        private const int TimeLimit = 10;

        private StreamWriter _writer;
        private int _timer;
        private bool _stop;
        private readonly List<string> _buffer;

        public LogBuffer()
        {
            _buffer = new List<string>();
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

        private void Add(string item)
        {
            _buffer.Add(item);
            _timer = 0;
            if (_buffer.Count >= MsgLimit)
            {
                Console.WriteLine("FLUSH");
                Flush();
            }
        }

        private void Flush()
        {
            int logCount = _buffer.Count;
            for (int i = 0; i < logCount; i++)
            {
                Console.WriteLine("PRINTING " + _buffer[0]);
                _writer.WriteLine(_buffer[0]);
                _buffer.RemoveAt(0);
            }
            _writer.Flush();
        }

        private void Listener()
        {
            while (!_stop)
            {
                _timer++;
                if (_timer == TimeLimit)
                {
                    Console.WriteLine("FLUSH");
                    Flush();
                    _timer = 0;
                }

                Thread.Sleep(1000);
            }
        }
    }
}