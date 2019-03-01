using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoToCartesian
{
    public interface IFunctions
    {


        Vector_t cartesian_geocentric_sdd108(double latitude, double longitude, double altitude);

        Vector_t normal_cartesian_sdd111(double phi_s, double lambda_s, double h_s, Vector_t cartesian_geocentric);

        Vector_t normal_cartesian_sdd111NEW(double phi_s, double lambda_s, double h_s, Vector_t cartesian_geocentricA, Vector_t cartesian_geocentricB);

        Vector_t related_cartesian_sdd112(Vector_t normal_cartesian, double h_s, double gamma, double theta, double psi);
    }


    //public class Vector_T{
        
    //}
}
