using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
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

                // инициализация
                radius = Ask.RealNum("Введите радиус: ", 10, 10000);
                lat1 = Ask.RealNum("Введите широту первой точки: ", -90, 90);
                long1 = Ask.RealNum("Введите долготу первой точки: ", -180, 180);
                lat2 = Ask.RealNum("Введите широту второй точки: ", -90, 90);
                long2 = Ask.RealNum("Введите долготу второй точки: ", -180, 180);

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
                
                Console.WriteLine("\nОтвет: " + ans);
                OC.Stay();
            }
        }
    }
}
