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
            double leftValue = Function.GetValue(leftPoint);
            double rightValue = Function.GetValue(rightPoint);

            while (Math.Abs(leftPoint - rightPoint) > accuracy)
            {
                if (leftValue < rightValue)
                {
                    rightPoint = (leftPoint + rightPoint) / 2;
                    rightValue = Function.GetValue(rightPoint);
                }
                else
                {
                    leftPoint = (leftPoint + rightPoint) / 2;
                    leftValue = Function.GetValue(leftPoint);
                }
            }

            return (leftPoint + rightPoint) / 2;
        }
    }
}
