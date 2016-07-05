using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KasperskyTestTasks
{
    class PQueue : IDisposable
    {
        EventWaitHandle waitHandler = new ManualResetEvent(false);
        Queue<Object> queue = new Queue<object>();
        object locker = new object();
        object locker2 = new object();
        volatile bool doWork = true;

        public Object pop()
        {
            while (doWork)
            {
                lock (locker)
                {
                    if (queue.Count > 0)
                    {
                        return queue.Dequeue();
                    }
                    else
                    {
                        if (doWork)
                            waitHandler.Reset();
                    }
                }

                waitHandler.WaitOne();
            }
            return null;
        }

        public void push(Object val)
        {
            lock (locker)
            {
                queue.Enqueue(val);
            }

            waitHandler.Set();
        }

        public void Dispose()
        {
            doWork = false;
            waitHandler.Set();
        }

    }
}
