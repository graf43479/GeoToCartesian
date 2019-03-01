using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToCartesian
{
    public class Vector_t
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Vector_t() { }

        public Vector_t(double xn, double yn, double zn)
        {
            x = xn;
            y = yn;
            z = zn;
        }

        public void SetVector(double xn, double yn, double zn)
        {
            x = xn;
            y = yn;
            z = zn;        
        }

    }
}
