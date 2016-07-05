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
        volatile bool doWork = true;
        /// <summary>
        /// Удаляет из очереди элемент и возвращает его.Если очередь пуста, то ждет пока не появится новый элемент
        /// </summary>
        /// <returns>Удаленный элемент или null, если очередь вызвала метод Dispose</returns>
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
        /// <summary>
        /// Вставляет елемент в очередь
        /// </summary>
        /// <param name="val">Вставляемый элемент</param>
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
