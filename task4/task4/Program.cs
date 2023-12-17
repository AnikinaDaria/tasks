using System;
using System.Collections.Generic;
using System.IO;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла");
            string path = Console.ReadLine();
            var listNums = new List<int>();
            using (StreamReader sr = new(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listNums.Add(int.Parse(line));
                }
            }
            listNums.Sort();
            var mid = listNums.Count / 2;
            var result = 0;
            foreach (var num in listNums)
            {
                result += Math.Abs(listNums[mid] - num);
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
