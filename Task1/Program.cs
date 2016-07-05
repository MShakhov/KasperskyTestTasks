using KasperskyTestTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter: 1-push, 2-pop or other number to exit");
            using (PQueue q = new PQueue())
            {
                int taskType = Convert.ToInt32(Console.ReadLine());
                while (taskType == 1 || taskType == 2)
                {
                    ParameterizedThreadStart thStart;

                    if (taskType == 1)
                    {
                        thStart = new ParameterizedThreadStart(Push);
                    }
                    else
                    {
                        thStart = new ParameterizedThreadStart(Pop);
                    }

                    Thread task = new Thread(thStart);
                    task.Start(q);

                    taskType = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.ReadKey();
        }
        /// <summary>
        /// Метод-обертка для вставки элемента в очередь
        /// </summary>
        /// <param name="queue"></param>
        static void Push(Object queue)
        {
            Random r = new Random();
            int val = r.Next();
            ((PQueue)queue).push(val);
            Console.WriteLine("push[{0}]", val);
        }
        /// <summary>
        /// Метод-обертка для удаления элемента из очереди
        /// </summary>
        /// <param name="queue"></param>
        static void Pop(Object queue)
        {
            Object val = ((PQueue)queue).pop();
            Console.WriteLine("pop[{0}]", ((val == null ? "null" : val.ToString())));
        }
    }
}
