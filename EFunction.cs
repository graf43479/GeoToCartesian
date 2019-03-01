using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeoToCartesian
{
   public class EFunction : IFunctions
    {

        const double E2 = (double)0.0066943661931;   //0066943661931;	// ПЗ-90.11
        // static const double E2 = 6.6943799901377997e-3;  //WGS-84 first eccentricity squared
        const double DEG_TO_RAD = (double)(Math.PI / 180);

        // Получение радиуса земного эллипсоида
        double ellipsoid_radius_sdd109(double phi)
        {
            return (double)(6378136 / Math.Sqrt(1 - E2 * Math.Sin(phi) * Math.Sin(phi)));
        }

      public  Vector_t cartesian_geocentric_sdd108(double latitude, double longitude, double altitude)
       {


          Vector_t v = new Vector_t();
          double rlat = latitude * DEG_TO_RAD;
          double rlon = longitude * DEG_TO_RAD;
          double clat = (double)Math.Cos(rlat);
          double slat = (double)Math.Sin(rlat);
          double ns = ellipsoid_radius_sdd109(rlat);
          double nph = ns + altitude;
          v.x = (double)(altitude );
        //  v.x = (double)(nph * clat * Math.Cos(rlon));
          v.y = (double)(nph * clat * Math.Sin(rlon));
           v.z = (ns * (1 - E2) + altitude) * slat;

           return  v;
       }


      public  Vector_t normal_cartesian_sdd111(double phi_s, double lambda_s, double h_s, Vector_t cartesian_geocentric)
       {
           return new Vector_t { };
       }

      public  Vector_t normal_cartesian_sdd111NEW(double phi_s, double lambda_s, double h_s, Vector_t cartesian_geocentricA, Vector_t cartesian_geocentricB)
       {
           double phi_s_rad = phi_s * DEG_TO_RAD;
           double lambda_s_rad = lambda_s * DEG_TO_RAD;
           //lambda_s *= DEG_TO_RAD;
           double n_s = ellipsoid_radius_sdd109(phi_s_rad);
           /*double x = cartesian_geocentric[0];
           double y = cartesian_geocentric[1];
           double z = cartesian_geocentric[2];
           */


           //new tactica
           double x1, x2, y1, y2, z1, z2, dx, dy, dz, xt, yt, zt;


           x1 = cartesian_geocentricA.x;
           y1 = cartesian_geocentricA.y;
           z1 = cartesian_geocentricA.z;

           x2 = cartesian_geocentricB.x;
           y2 = cartesian_geocentricB.y;
           z2 = cartesian_geocentricB.z;

           dx = x2 - x1;
           dy = y2 - y1;
           dz = z2 - z1;



        
           xt = (double)(-dx * Math.Sin(phi_s_rad) * Math.Cos(lambda_s_rad) - dy * Math.Sin(phi_s_rad) * Math.Sin(lambda_s_rad) + dz * Math.Cos(phi_s_rad));
           yt = (double)(dx * Math.Sin(lambda_s_rad) - dy * Math.Cos(lambda_s_rad));
           zt = (double)(dx * Math.Cos(phi_s_rad) * Math.Cos(lambda_s_rad) + dy * Math.Cos(phi_s_rad) * Math.Sin(lambda_s_rad) + dz * Math.Sin(phi_s_rad));

           //end

           return new Vector_t(xt, zt, -yt);



      
       }

      public  Vector_t related_cartesian_sdd112(Vector_t normal_cartesian, double h_s, double gamma, double theta, double psi)
       {
           double x1 = normal_cartesian.x;
           double y1 = normal_cartesian.y;
           double z1 = normal_cartesian.z;
           double y = y1 - h_s;

           double psi_r = psi * DEG_TO_RAD;
           double theta_r = theta * DEG_TO_RAD;
           double gamma_r = gamma * DEG_TO_RAD;

           Vector_t v = new Vector_t();

           v.x = (double)(x1 * Math.Cos(psi_r) * Math.Cos(theta_r) +
               y * Math.Sin(theta_r) - z1 * Math.Sin(psi_r) * Math.Cos(theta_r));

           v.y = (double)(x1 * (Math.Sin(gamma_r) * Math.Sin(psi_r) - Math.Cos(gamma_r) * Math.Cos(psi_r) * Math.Sin(theta_r)) +
               y1 * Math.Cos(gamma_r) * Math.Cos(theta_r) + z1 * (Math.Sin(gamma_r) * Math.Cos(psi_r) + Math.Cos(gamma_r) * Math.Sin(psi_r) * Math.Sin(theta_r)));

           v.z = (double)(x1 * (Math.Cos(gamma_r) * Math.Sin(psi_r) + Math.Sin(gamma_r) * Math.Cos(psi_r) * Math.Sin(theta_r)) -
               y1 * Math.Sin(gamma_r) * Math.Cos(theta_r) + z1 * (Math.Cos(gamma_r) * Math.Cos(psi_r) - Math.Sin(gamma_r) * Math.Sin(psi_r) * Math.Sin(theta_r)));

           return v;
       }
    }
}
