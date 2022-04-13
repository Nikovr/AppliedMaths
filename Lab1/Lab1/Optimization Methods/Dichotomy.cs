using System;

namespace Lab1.Optimization_Methods
{
    public class Dichotomy 
    {
        public Dichotomy()
        {
        }
        public double Start(double accuracy, double leftPoint, double rightPoint)
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
