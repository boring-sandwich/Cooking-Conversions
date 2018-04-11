using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking_Conversions
{
    partial class Temperature
    {
        public double CelsiusToFahrenheit(double dubCelsius)
        {
            double dubFahrenheit;
            dubFahrenheit = dubCelsius * 9 / 5 + 32;
            return dubFahrenheit;
        }

        public double FahrenheitToCelsius(double dubFahrenheit)
        {
            double dubCelsius;
            dubCelsius = (dubFahrenheit - 32) * 5 / 9;
            return dubCelsius;
        }

        public double CelsiusToGasMark(double dubCelsius)
        {
            double dubGasMark;
            if (dubCelsius <= 139)
            {
                dubGasMark = 0;
                return dubGasMark;
            }
            else if (dubCelsius >= 231)
            {
            dubGasMark = 0;
                return dubGasMark;
            }
            else if (dubCelsius <= 230)
            {
                if (dubCelsius <= 220)
                {
                    if (dubCelsius <= 200)
                    {
                        if (dubCelsius <= 190)
                        {
                            if (dubCelsius <= 180)
                            {
                                if (dubCelsius <= 160)
                                {
                                    if (dubCelsius <= 150)
                                    {
                                        if (dubCelsius <= 140)
                                        {
                                            dubGasMark = 1;
                                            return dubGasMark;
                                        }
                                        dubGasMark = 2;
                                        return dubGasMark;
                                    }
                                    dubGasMark = 3;
                                    return dubGasMark;
                                }
                                dubGasMark = 4;
                                return dubGasMark;
                            }
                            dubGasMark = 5;
                            return dubGasMark;
                        }
                        dubGasMark = 6;
                        return dubGasMark;
                    }
                    dubGasMark = 7;
                    return dubGasMark;
                }
                dubGasMark = 8;
                return dubGasMark;
            }
            dubGasMark = 0;
            return dubGasMark;
        }

        public double FahrenheitToGasMark(double dubFahrenheit)
        {
            double dubGasMark;
            if (dubFahrenheit <= 274)
            {
                dubGasMark = 0;
                return dubGasMark;
            }
            else if (dubFahrenheit >= 451)
            {
                dubGasMark = 0;
                return dubGasMark;
            }
            else if (dubFahrenheit <= 450)
            {
                if (dubFahrenheit <= 425)
                {
                    if (dubFahrenheit <= 400)
                    {
                        if (dubFahrenheit <= 375)
                        {
                            if (dubFahrenheit <= 350)
                            {
                                if (dubFahrenheit <= 325)
                                {
                                    if (dubFahrenheit <= 300)
                                    {
                                        if (dubFahrenheit <= 275)
                                        {
                                            dubGasMark = 1;
                                            return dubGasMark;
                                        }
                                        dubGasMark = 2;
                                        return dubGasMark;
                                    }
                                    dubGasMark = 3;
                                    return dubGasMark;
                                }
                                dubGasMark = 4;
                                return dubGasMark;
                            }
                            dubGasMark = 5;
                            return dubGasMark;
                        }
                        dubGasMark = 6;
                        return dubGasMark;
                    }
                    dubGasMark = 7;
                    return dubGasMark;
                }
                dubGasMark = 8;
                return dubGasMark;
            }
            dubGasMark = 0;
            return dubGasMark;
        }
    }
}
