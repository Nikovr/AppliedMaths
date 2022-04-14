using System;

namespace Lab1.Optimization_Methods
{
    public class Parabola
    {

        public Parabola()
        {
        }

        public double Start(double accuracy, double leftPoint, double rightPoint)
        {
            var middlePoint = rightPoint - leftPoint;

            double lastApex = 1000000000;
            double apexOfParabola = 0;
            
            var fLeft = Function.GetValue(leftPoint);
            var fMiddle = Function.GetValue(middlePoint);
            var fRight = Function.GetValue(rightPoint);

            while (Math.Abs(lastApex - apexOfParabola) > accuracy)
            {
                var midMleft = middlePoint - leftPoint;
                var midMright = middlePoint - rightPoint;

                var f_midMleft = fMiddle - fLeft;
                var f_midMright = fMiddle - fRight;

                var Numerator = Math.Pow(midMleft, 2) * f_midMright - Math.Pow(midMright, 2) * f_midMleft;
                var Denominator = midMleft * f_midMright - midMright * f_midMleft;

                if (Denominator == 0)
                    return middlePoint;
                var Fraction = Numerator / Denominator / 2;


                apexOfParabola = middlePoint - Fraction;

                if (apexOfParabola < leftPoint)
                {
                    if (Function.GetValue(apexOfParabola) < fMiddle)
                    {
                        middlePoint = leftPoint;
                        rightPoint = leftPoint;
                        fMiddle = fLeft;
                        fRight = fLeft;
                    }
                    else
                    {
                        leftPoint = rightPoint;
                        middlePoint = rightPoint;
                        fLeft = fRight;
                        fMiddle = fRight;
                    }
                }
                else if (apexOfParabola > leftPoint)
                {
                    if (Function.GetValue(apexOfParabola) < fMiddle)
                    {
                        rightPoint = middlePoint;
                        fRight = fMiddle;
                        middlePoint = apexOfParabola;
                        fMiddle = Function.GetValue(apexOfParabola);
                    }
                    else
                    {
                        leftPoint = apexOfParabola;
                        fLeft = Function.GetValue(apexOfParabola);
                    }
                } 
                else if (apexOfParabola > middlePoint)
                {
                    if (Function.GetValue(apexOfParabola) < fMiddle)
                    {
                        leftPoint = middlePoint;
                        fLeft = fMiddle;
                        middlePoint = apexOfParabola;
                        fMiddle = Function.GetValue(apexOfParabola);
                    }
                    else
                    {
                        rightPoint = apexOfParabola;
                        fRight = Function.GetValue(apexOfParabola);
                    }
                    
                }
                else if (apexOfParabola > rightPoint)
                {
                    if (Function.GetValue(apexOfParabola) < fMiddle)
                    {
                        leftPoint = rightPoint;
                        middlePoint = rightPoint;
                        fMiddle = fRight;
                        fLeft = fRight;
                    }
                    else
                    {
                        middlePoint = leftPoint;
                        rightPoint = leftPoint;
                        fMiddle = fLeft;
                        fRight = fLeft;
                    }
                }
                lastApex = apexOfParabola;
                
            }

            return apexOfParabola;
        }
    }
}
