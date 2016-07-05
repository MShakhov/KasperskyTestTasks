using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Array length= ");
            int lenArr = Convert.ToInt32(Console.ReadLine());

            Console.Write("Max element in array= ");
            int mod = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[lenArr];

            Random r = new Random();
            for(int i=0;i<lenArr;i++)
            {
                arr[i] = r.Next() % mod;

                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();

            Console.Write("X= ");
            int X = Convert.ToInt32(Console.ReadLine());

            ShowAllPairNumSumIsEqualX(arr, X);

            Console.ReadKey();
        }
        /// <summary>
        /// Вывод всех пар чисел, которые в сумме равны заданному Х
        /// </summary>
        /// <param name="arr">Коллекция чисел</param>
        /// <param name="X">Заданное число</param>
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
    }
}
