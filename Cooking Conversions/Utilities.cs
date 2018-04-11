using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking_Conversions
{
    class Utilities
    {
        public double Rounding(double dblAnswer)
        {
            dblAnswer = dblAnswer * 4;
            dblAnswer = Math.Ceiling(dblAnswer);
            dblAnswer = dblAnswer / 4;
            return dblAnswer;
        }
        public  int Rounding (int intAnswer)
        {
            intAnswer = intAnswer * 4;
            double dblAnswer = intAnswer;
            dblAnswer = Math.Ceiling(dblAnswer);
            dblAnswer = dblAnswer / 4;
            dblAnswer = Math.Round(dblAnswer);
            intAnswer = (int)dblAnswer;
            return intAnswer;

        }
    }
}
