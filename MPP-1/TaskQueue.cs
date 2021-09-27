using System.Collections.Generic;
using System.Threading;

namespace MPP_1
{
    public class TaskQueue
    {
        private readonly Queue<TaskDelegate> _tasks;
        private int _workingThreads;
        private readonly object _locker = new object();

        public delegate void TaskDelegate();

        public TaskQueue(int quantityOfThreads)
        {
            _tasks = new Queue<TaskDelegate>();
            Thread[] threadPool = new Thread[quantityOfThreads];
            for (int i = 0; i < quantityOfThreads; i++)
            {
                threadPool[i] = new Thread(RunThreadTask) {IsBackground = true};
                threadPool[i].Start();
            }
        }

        void RunThreadTask()
        {
            while (true)
            {
                TaskDelegate task = null;

                lock (_locker)
                {
                    _workingThreads++;
                }

                lock (_tasks)
                {
                    if (_tasks.Count != 0)
                    {
                        task = _tasks.Dequeue();
                    }
                }

                task?.Invoke();

                lock (_locker)
                {
                    _workingThreads--;
                }
            }
        }

        public bool IsReadyToStop()
        {
            lock (_locker)
            {
                return _workingThreads == 0 && _tasks.Count == 0;
            }
        }

        public void EnqueueTaskDelegate(TaskDelegate task)
        {
            lock (_tasks)
            {
                _tasks.Enqueue(task);
            }
        }
    }
}