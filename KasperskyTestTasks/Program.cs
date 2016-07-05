using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KasperskyTestTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            PQueue q = new PQueue();

            Console.WriteLine("Please key 1-push 2-pop and other key - exit");
            int taskType = Convert.ToInt32(Console.ReadLine());
            while (taskType == 1 || taskType == 2)
            {
                if(taskType == 1)
                {
                    Thread t2 = new Thread(new ParameterizedThreadStart(Push));
                    t2.Start(q);
                }
                else
                {
                    Thread t2 = new Thread(new ParameterizedThreadStart(Pop));
                    t2.Start(q);
                }

                taskType = Convert.ToInt32(Console.ReadLine());
            }

            q.Dispose();

            Console.ReadKey();

        }

        static void ShowAllPairNumSumIsEqualX(IEnumerable<int> arr, int X)
        {
            if (arr == null) return;
            int[] sortedarr = arr.Where(el => el <= X).OrderBy(el => el).ToArray();

            int borderSearch = X / 2;
            int len = sortedarr.Length;
            for (int i = 0; i < len && sortedarr[i] <= borderSearch; i++)
            {
                if (i == 0 || sortedarr[(i - 1)] != sortedarr[i])
                {
                    int searchVal = X - sortedarr[i];

                    if (Array.BinarySearch(sortedarr, i + 1, len - i - 1, searchVal) > 0)
                    {
                        Console.WriteLine("({0};{1})", sortedarr[i], searchVal);
                    }
                }
            }

        }

        static void Push(Object queue)
        {
            Random r = new Random();
            int val = r.Next();
            ((PQueue)queue).push(val);
            Console.WriteLine("push[{0}]", val);
        }

        static void Pop(Object queue)
        {
            Object val = ((PQueue)queue).pop();
            Console.WriteLine("pop[{0}]", ((val == null ? "null" : val.ToString())));
        }

   
    }
}
