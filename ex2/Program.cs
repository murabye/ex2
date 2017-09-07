using System;
using System.IO;

namespace ex2
{
    internal class Program
    {

        private static void Main()
        {
            double radius; // радиус, от 100 до 10 000 
            double lat1, lat2, long1, long2;

            var reader = new FileInOut("input");

            // инициализация
            radius = Double.Parse(reader.Next());
            lat1 =  Double.Parse(reader.Next());
            long1 = Double.Parse(reader.Next());
            lat2 =  Double.Parse(reader.Next());
            long2 = Double.Parse(reader.Next());

            // перевод в радианы
            double x1 = radius * Math.Cos(lat1) * Math.Cos(long1);
            double x2 = radius * Math.Cos(lat2) * Math.Cos(long2);
            double y1 = radius * Math.Cos(lat1) * Math.Sin(long1);
            double y2 = radius * Math.Cos(lat2) * Math.Sin(long2);
            double z1 = radius * Math.Sin(lat1);
            double z2 = radius * Math.Sin(lat2);

            // поиск расстояния между точками по прямой
            double D = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
            if (D > 2 * radius) D = 2 * radius;

            double tangleA = 2 * Math.Asin((D / 2) / radius);
            FileInOut.ToFile("output", tangleA.ToString("#.##").Replace(',', '.'));
        }

        // класс для считывания и записи в файл
        internal class FileInOut
    {
        private string[] _obj;                      // строки, которые нужно считать
        private int position = 0;                   // позиция считывателя

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
