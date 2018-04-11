using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking_Conversions
{
    class MeasurementConversions
    {
        private const double METERS = 3.28;
        private const double CENTIMETERS = 0.39;
        private const double MILLIMETERS = 0.039;

        public double Meters2Feet(double dblMeters)
        {
            double dblAns = dblMeters * METERS;
            return dblAns;
        }

        public double Centimeters2Inches(double dblCentimeters)
        {
            double dblAns = dblCentimeters * CENTIMETERS;
            return dblAns;
        }

        public double Millimeters2Inches(double dblMillimeters)
        {
            double dblAns = dblMillimeters * MILLIMETERS;
            return dblAns;
        }

    }
}
