using System;
namespace Lab1.OptimizationMethods
{
    public class Brent
    {
        private readonly double _proportion = (3 - Math.Sqrt(5)) / 2;
        
        public double Brent1(double accuracy, double leftPoint, double rightPoint)
        {
            var downPoint = leftPoint + _proportion * (rightPoint - leftPoint);
            var middlePoint = leftPoint + _proportion * (rightPoint - leftPoint);
            var upPoint = leftPoint + _proportion * (rightPoint - leftPoint);
            var stepCur = rightPoint - leftPoint; //Инициализация текущего шага
            var stepPrv = rightPoint - leftPoint; //Инициализация предыдущего шага
            var fx1 = Function.GetValue(downPoint);
            var fx2 = Function.GetValue(downPoint);
            var fx3 = Function.GetValue(downPoint);

            while (true)
            {
                var g = stepPrv / 2;
                stepPrv = stepCur;
                
                if (Math.Max(downPoint - leftPoint, rightPoint - downPoint) < accuracy)
                {
                    return downPoint;
                }
                
                //парабо
                var middleMinusLeft = middlePoint - downPoint;
                var middleMinusRight = middlePoint - upPoint;

                var funcMiddleMinusLeft = fx2 - fx1;
                var funcMiddleMinusRight = fx2 - fx3;

                var numerator = Math.Pow(middleMinusLeft, 2) * funcMiddleMinusRight - Math.Pow(middleMinusRight, 2) * funcMiddleMinusLeft;
                var denominator = middleMinusLeft * funcMiddleMinusRight - middleMinusRight * funcMiddleMinusLeft;

                double fraction = 0;
                double topOfParabola = 0;
                
                if (denominator != 0)
                {
                    fraction = numerator / denominator / 2;
                    topOfParabola = middlePoint - fraction;
                }
                else
                { 
                    topOfParabola = downPoint;
                }
                var fa = Function.GetValue(topOfParabola);

                if (topOfParabola < leftPoint || topOfParabola > rightPoint || topOfParabola == downPoint || Math.Abs(topOfParabola - downPoint) > g)
                {

                    if (downPoint < leftPoint + _proportion * (rightPoint - leftPoint))
                    {
                        topOfParabola = downPoint + _proportion * (rightPoint - downPoint);
                        stepPrv = rightPoint - downPoint;
                    }
                    else
                    {
                        var u = downPoint + _proportion * (rightPoint - downPoint);
                        stepPrv = rightPoint - downPoint;
                    }

                    fa = Function.GetValue(topOfParabola);
                }
                stepCur = Math.Abs(topOfParabola - downPoint);
                if (fa > fx1)
                {
                    if (topOfParabola < downPoint)
                    {
                        leftPoint = topOfParabola;
                    }
                    else
                    {
                        rightPoint = topOfParabola;
                    }

                    if (fa <= fx2 || middlePoint == downPoint)
                    {
                        upPoint = middlePoint;
                        fx3 = fx2;
                        middlePoint = topOfParabola;
                        fx2 = fa;
                    }
                    else
                    {
                        if (fa < fx3 || upPoint == downPoint || upPoint == middlePoint)
                        {
                            upPoint = topOfParabola;
                            fx3 = fa;
                        }
                    }
                }
                else
                {
                    if (topOfParabola < downPoint)
                    {
                        rightPoint = downPoint;
                    }
                    else
                    {
                        leftPoint = downPoint;
                    }

                    upPoint = middlePoint;
                    fx3 = fx2;
                    middlePoint = downPoint;
                    fx2 = fx1;
                    downPoint = topOfParabola;
                    fx1 = fa;
                }
            }
        }
    }
}
