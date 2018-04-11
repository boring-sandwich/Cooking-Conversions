using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking_Conversions
{
    class TipsConversions
    {
        public const int INTGRAMS = 115;
        public const int INTCUPS = 110;
        public const int INTOUNCES = 4;

        Utilities u = new Utilities();

        //grams to tsp
        public int Grams2TSP (int intGrams)
        {
            int intAnswer = intGrams / INTGRAMS;
            intAnswer = u.Rounding(intAnswer);
            return intAnswer;
        }
        public double TSPSALT(double dblTsp)
        {
            double dblAns = dblTsp / 4;
            return dblAns;
        }

        //ounces to tsp
        public int Ounces2TSP(int intGrams)
        {
            int intAnswer = intGrams /INTOUNCES;
            intAnswer = u.Rounding(intAnswer);
            return intAnswer;
        }
    }
}
