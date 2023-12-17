using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите m");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            var arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = i + 1;
            int index = 0;
            do{ 
                Console.Write(arr[index]);
                index = (index + m - 1) % n;
            } while (index != 0);
            Console.ReadKey();
        }
    }
}
