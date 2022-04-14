using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Function
    {
        public static double GetValue(double x)
        {
            return Math.Sin(x * Math.PI / 180) * Math.Pow(x, 2);
        }
    }
}
