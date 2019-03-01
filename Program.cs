using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToCartesian
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
       
            double x1 = (double)0.112765;
            double y1 = (double)0;
            double z1 = (double)2000;
            double angle1 = (double)0;

            double x2 = (double)0.31;
            double y2 = (double)(-0.354443);
            double z2 = (double)1000;

            EFunction ef = new EFunction();

            //ownship
            Vector_t ecef1 = ef.cartesian_geocentric_sdd108(x1, y1, z1);
            //other ship
            Vector_t ecef2 = ef.cartesian_geocentric_sdd108(x2, y2, z2);

            Vector_t normalCartesian = ef.normal_cartesian_sdd111NEW(x1, y1, z1, ecef1, ecef2);
            
            Vector_t relatedCartesian = ef.related_cartesian_sdd112(normalCartesian, z1, 0, 0, angle1);

            Console.WriteLine("ShipA: \nX: {0};\nY: {1};\nZ: {2};\nCourse: {3}; ", x1, y1, z1, angle1);
            Console.WriteLine("--------------");
            Console.WriteLine("ShipB: \nX: {0};\nY: {1};\nZ: {2}; ", x2, y2, z2);
            Console.WriteLine();
            Console.WriteLine("===========Step1===========");
            Console.WriteLine("ShipA: \nX: {0};\nY: {1};\nZ: {2}; ", ecef1.x, ecef1.y, ecef1.z);
            Console.WriteLine("--------------");
            Console.WriteLine("ShipB: \nX: {0};\nY: {1};\nZ: {2}; ", ecef2.x, ecef2.y, ecef2.z);
            Console.WriteLine();
            Console.WriteLine("===========Step2===========");
            Console.WriteLine("ShipA: \nX: {0};\nY: {1};\nZ: {2}; ", normalCartesian.x, normalCartesian.y, normalCartesian.z);
            Console.WriteLine();
            Console.WriteLine("===========Step3===========");
            Console.WriteLine("ShipA: \nX: {0};\nY: {1};\nZ: {2}; ", relatedCartesian.x, relatedCartesian.y, relatedCartesian.z);
        }
    }
}
