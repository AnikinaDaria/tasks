using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace task2
{
    class Program
    {
        public static float[] PointsXY(string point)
        {
            string[] pointXY = point.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            float pointX = float.Parse(pointXY[0].Replace(',', '.'), CultureInfo.InvariantCulture.NumberFormat);
            float pointY = float.Parse(pointXY[1].Replace(',', '.'), CultureInfo.InvariantCulture.NumberFormat);
            return new float[] { pointX, pointY };
        }

        public static List<string> ReadFile(string path)
        {
            var listPoints = new List<string>();
            using (StreamReader sr = new(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listPoints.Add(line);
                }
            }
            return listPoints;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла1");
            string path1 = Console.ReadLine();
            Console.WriteLine("Введите путь до файла2");
            string path2 = Console.ReadLine();
            Console.WriteLine();
            var listCenter = ReadFile(path1);
            var listPoints = ReadFile(path2);

            float radius = float.Parse(listCenter[1].Replace(',', '.'), CultureInfo.InvariantCulture.NumberFormat);
            var centerXY = PointsXY(listCenter[0]);
            float centerX = centerXY[0];
            float centerY = centerXY[1];

            var pointsXY = new List<float[]>();
            foreach (var point in listPoints)
            {
                pointsXY.Add(PointsXY(point));
            }

            foreach (var point in pointsXY)
            {
                var result = Math.Sqrt(Math.Pow(centerX - point[0], 2) + Math.Pow(centerY - point[1], 2));
                if (result == radius)
                    Console.Write("0\n");
                else if (result < radius)
                    Console.Write("1\n");
                else Console.Write("2\n");
            }
            Console.ReadKey();
        }
    }
}
