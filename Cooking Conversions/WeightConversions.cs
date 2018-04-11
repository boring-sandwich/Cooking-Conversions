using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking_Conversions
{
    class WeightConversionsFlour
    {
        // constants
        private const double DBLPOUNDS = 2.2046;
        private const double DBLOUNCES = 0.035;
        private const double DBLG2POUNDS = 0.002205;
        private const double DBLCUPS = 110.00;
        public double KilogramsToPounds(double dblKilograms)
        {
            double dblAnswer = dblKilograms * DBLPOUNDS;
            return dblAnswer;
        }

        public double GramsToOunces(double dblGrams)
        {
            double dblAnswer = dblGrams * DBLOUNCES;
            return dblAnswer;
        }

        public double GramsToPounds(double dblGrams)
        {
            double dblAnswer = dblGrams * DBLG2POUNDS;
            return dblAnswer;
        }

        public double GramsToCups(double dblGrams)
        {
            double dblAnswer = dblGrams / DBLCUPS;
            return dblAnswer;
        }
    }
    class WeightConversionsSugar
    {

        public double GramsToOunces(double dblGrams)
        {
            double dblAns = (dblGrams / 200) * 7;
            return dblAns;
        }

        public double GramsToPounds(double dblGrams)
        {
            double dblAns = (dblGrams / 200) * 0.44;
            return dblAns;
        }

        public double GramsToCups(double dblGrams)
        {
            double dblAns = dblGrams / 200;
            return dblAns;
        }
    }
    class WeightConversionButter
    {
        private const double DBLPOUNDS = 0.50265395778;
        
        public double GramsToCups (double dblGrams)
        {
            double dblAns = dblGrams / 228;
            return dblAns;
        }
        public double GramsToOunces (double dblGrams)
        {
            double dblAns = (dblGrams / 228) * 8;
            return dblAns;
        }
        public double GramsToPounds(double dblGrams)
        {
            double dblAns = (dblGrams / 228) * DBLPOUNDS;
            return dblAns;
        }
    }
    class WeightConversionOil
    {
        public double GramsToCups(double dblGrams)
        {
            double dblAns = dblGrams / 215;
            return dblAns;
        }
        public double GramsToOunces(double dblGrams)
        {
            double dblAns = (dblGrams / 215) * 7.5;
            return dblAns;
        }
    }

}
