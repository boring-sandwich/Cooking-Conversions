using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking_Conversions
{
    class VolumeConversions
    {
        private const double DBLQUARTS = 1.057;
        private const double DBLGALLONS = 0.264;
        private const double DBLCUPS = 0.0042;
        private const double DBLOUNCES = 0.0338;

        public double LitersToQuarts(double dblLiters)
        {
            double dblAns = dblLiters * DBLQUARTS;
            return dblAns;
        }

        public double LitersToGallons(double dblLiters)
        {
            double dblAns = dblLiters * DBLGALLONS;
                return dblAns;
        }

        public double MillilitersToCups(double dblMilliliters)
        {
            double dblAns = dblMilliliters * DBLCUPS;
            return dblAns;
        }

        public double MillilitersToOunces(double dblMilliliters)
        {
            double dblAns = dblMilliliters * DBLOUNCES;
            return dblAns;
        }
    }
}
