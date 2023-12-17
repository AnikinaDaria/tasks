using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using task3.Models;

namespace task3
{
    class Program
    {
        public static RootobjectTests newTests;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла tests.json");
            string path2 = Console.ReadLine();
            using (StreamReader sr = new(path2, System.Text.Encoding.Default))
            {
                string json = sr.ReadToEnd();
                RootobjectTests tests = JsonConvert.DeserializeObject<RootobjectTests>(json);
                newTests = tests;
            }

            Console.WriteLine("Введите путь до файла values.json");
            string path1 = Console.ReadLine();
            var values = new RootobjectValues();
            using (StreamReader sr = new(path1, System.Text.Encoding.Default))
            {
                string json = sr.ReadToEnd();
                values = JsonConvert.DeserializeObject<RootobjectValues>(json);
            }

            WriteValue(newTests.tests, values);
            var jsonOut = JsonConvert.SerializeObject(newTests);
            var pathOut = Path.Combine("result", "report.json");
            File.WriteAllText(pathOut,jsonOut);
            Console.WriteLine("Файл сформирован в папке result");
            Console.ReadKey();
        }
        public static void WriteValue(List<Test> tests, RootobjectValues values)
        {
            foreach (var test in tests)
            {
                var idValue = values.values.Where(v => v.id == test.id).FirstOrDefault();
                if (idValue != null)
                    test.value = idValue.value;
                else test.value = "";
                if (test.values != null)
                    WriteValue(test.values, values);
            }
        }
    }
}
