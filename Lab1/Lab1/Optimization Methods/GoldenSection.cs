using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Optimization_Methods
{
    public class GoldenSection
    {
        private readonly double GoldenRatio = (1 + Math.Sqrt(5)) / 2;

        public GoldenSection()
        {
        }

        public double Start(double accuracy, double leftPoint, double rightPoint)
        {
            double left = rightPoint - Math.Abs(leftPoint - rightPoint) / GoldenRatio;
            double right = leftPoint + Math.Abs(leftPoint - rightPoint) / GoldenRatio;

            double leftValue = Function.GetValue(left);
            double rightValue = Function.GetValue(right);

            while (Math.Abs(leftPoint - rightPoint) > accuracy)
            {
                if (leftValue < rightValue)
                {
                    rightPoint = right;
                    right = left;
                    rightValue = leftValue;
                    left = rightPoint - Math.Abs(leftPoint - rightPoint) / GoldenRatio;
                    leftValue = Function.GetValue(left);
                }
                else
                {
                    leftPoint = left;
                    left = right;
                    leftValue = rightValue;
                    right = leftPoint + Math.Abs(leftPoint - rightPoint) / GoldenRatio;
                    rightValue = Function.GetValue(right);
                }
            }

            return (leftPoint + rightPoint) / 2;
        }
    }
}
