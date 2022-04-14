using System;
namespace Lab1.OptimizationMethods
{
    public class Brent
    {
        private readonly double _proportion = (3 - Math.Sqrt(5)) / 2;

        public Brent()
        {
        }

        public double Brent1(double accuracy, double leftPoint, double rightPoint)
        {
            var x1 = leftPoint + _proportion * (rightPoint - leftPoint);
            var middlePoint = leftPoint + _proportion * (rightPoint - leftPoint);
            var x3 = leftPoint + _proportion * (rightPoint - leftPoint);
            var dCur = rightPoint - leftPoint;
            var dPrv = rightPoint - leftPoint;
            var fx1 = Function.GetValue(x1);
            var fx2 = Function.GetValue(x1);
            var fx3 = Function.GetValue(x1);

            while (true)
            {
                if (Math.Max(x1 - leftPoint, rightPoint - x1) < accuracy)
                {
                    return 0;
                }

                var g = dPrv / 2;
                dPrv = dCur;

                var middleMinusLeft = middlePoint - x1;
                var middleMinusRight = middlePoint - x3;

                var funcMML = fx2 - fx1;
                var funcMMR = fx2 - fx3;

                var numerator = Math.Pow(middleMinusLeft, 2) * funcMMR - Math.Pow(middleMinusRight, 2) * funcMML;
                var denominator = middleMinusLeft * funcMMR - middleMinusRight * funcMML;

                double fraction = 0;
                double topOfParabola = 0;
                
                if (denominator != 0)
                {
                    fraction = numerator / denominator / 2;
                    topOfParabola = middlePoint - fraction;
                }
                else
                { 
                    topOfParabola = x1;
                }
                var fa = Function.GetValue(topOfParabola);

                if (topOfParabola < leftPoint || topOfParabola > rightPoint || topOfParabola == x1 || Math.Abs(topOfParabola - x1) > g)
                {

                    if (x1 < (leftPoint + rightPoint) / 2)
                    {
                        topOfParabola = x1 + _proportion * (rightPoint - x1);
                        dPrv = rightPoint - x1;
                    }
                    else
                    {
                        var u = x1 + _proportion * (rightPoint - x1);
                        dPrv = rightPoint - x1;
                    }

                    fa = Function.GetValue(topOfParabola);
                }
                dCur = Math.Abs(topOfParabola - x1);
                if (fa > fx1)
                {
                    if (topOfParabola < x1)
                    {
                        leftPoint = topOfParabola;
                    }
                    else
                    {
                        rightPoint = topOfParabola;
                    }

                    if (fa <= fx2 || middlePoint == x1)
                    {
                        x3 = middlePoint;
                        fx3 = fx2;
                        middlePoint = topOfParabola;
                        fx2 = fa;
                    }
                    else
                    {
                        if (fa < fx3 || x3 == x1 || x3 == middlePoint)
                        {
                            x3 = topOfParabola;
                            fx3 = fa;
                        }
                    }
                }
                else
                {
                    if (topOfParabola < x1)
                    {
                        rightPoint = x1;
                    }
                    else
                    {
                        leftPoint = x1;
                    }

                    x3 = middlePoint;
                    fx3 = fx2;
                    middlePoint = x1;
                    fx2 = fx1;
                    x1 = topOfParabola;
                    fx1 = fa;
                }
            }
        }
    }
}
