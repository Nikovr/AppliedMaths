using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public static class Dichotomy 
    {
        public static double Start(double accuracy, double leftPoint, double rightPoint)
        {
            while (Math.Abs(leftPoint - rightPoint) > accuracy)
            {
                if (Function.GetValue(leftPoint) < Function.GetValue(rightPoint))
                {
                    rightPoint = (leftPoint + rightPoint) / 2;
                }
                else
                {
                    leftPoint = (leftPoint + rightPoint) / 2;
                }
            }

            return (leftPoint + rightPoint) / 2;
        }
    }
}
