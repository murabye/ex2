using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace ex2
{
    internal class Program
    {
        private static void Main()
        {
            double radius;                      // радиус, от 100 до 10 000 

            // первая точка - индекс 0, вторая - 1.
            var latitude = new double[2];       // широра, от -90 до 90. 
            var longitude = new double[2];      // долгота, от -180 до 180

            // инициализация
            radius = Ask.RealNum("Введите радиус: ", 10, 10000);
            latitude[0] = Ask.RealNum("Введите широту первой точки: ", -180, 180);
            longitude[0] = Ask.RealNum("Введите долготу первой точки: ", -90, 90);
            latitude[1] = Ask.RealNum("Введите широту второй точки: ", -180, 180);
            longitude[1] = Ask.RealNum("Введите долготу второй точки: ", -90, 90);


        }
    }
}
