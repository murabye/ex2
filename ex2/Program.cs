using System;
using System.IO;
using static System.Math;

namespace ex2
{
    internal class Program
    {
        private static double ToRad(double grad)
        {
            return grad * Math.PI / 180;
        }

        private static void Main()
        {
            while (true)
            {
                double radius; // радиус, от 100 до 10 000 
                double lat1, lat2, long1, long2;
                var reader = new FileInOut("input");

                // инициализация
                radius = Double.Parse(reader.Next().Replace('.', ','));
                lat1 =  Double.Parse(reader.Next().Replace('.', ','));
                long1 = Double.Parse(reader.Next().Replace('.', ','));
                lat2 =  Double.Parse(reader.Next().Replace('.', ','));
                long2 = Double.Parse(reader.Next().Replace('.', ','));

                // перевод в радианы
                lat1 = ToRad(lat1);
                lat2 = ToRad(lat2);
                long1 = ToRad(long1);
                long2 = ToRad(long2);

                // синусы и косинусы для вычисления
                double x, y;

                // вычисления
                // формула гаверсинусов с модификацией для антиподов
                y = Sqrt(Pow(Cos(lat2) * Sin(long2 - long1), 2) 
                    + Pow(Cos(lat1) * Sin(lat2)
                    - Sin(lat1) * Cos(lat2) * Cos(long2 - long1), 2));

                x = Sin(lat1) * Sin(lat2)
                    + Cos(lat1) * Cos(lat2) * Cos(long2 - long1);
                
                double ans = Atan2(y, x) * radius;

                FileInOut.ToFile("output", ans.ToString("#.##").Replace(',', '.'));
            }
        }
    }


    // класс для считывания и записи в файл
    internal class FileInOut
    {
        private string[] _obj; // строки, которые нужно считать
        private int position = 0; // позиция считывателя

        /* конструктор для ввода из файла
         * name - название файла
         * НЕ ПОДДЕРЖИВАЕТСЯ выбор пути, все в папку исходную
         */
        public FileInOut(string name)
        {
            var _reader = new StreamReader(name + ".txt");
            var strings = _reader.ReadToEnd();
            _obj = strings.Split('\n', ' ');

            _reader.Close();
        }

        // возрващает считываемую строку, делит по пробелам
        public string Next()
        {
            try
            {
                return _obj[position++];
            }
            catch (Exception e)
            {
                return " ";
            }
        }

        /* вывод в файл name строки obj
         * name вводится без расширения
         * НЕ ПОДДЕРЖИВАЕТСЯ выбор пути, все в папку исходную
         */
        public static void ToFile(string name, string obj)
        {
            var f = new StreamWriter(name + ".txt");
            var strings = obj.Split('\n');

            foreach (var t in strings)
                f.WriteLine(t);

            f.Close();
        }

    }
}
