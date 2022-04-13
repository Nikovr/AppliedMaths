using System;
using System.Collections.Generic;

namespace Lab1.Optimization_Methods
{
    public class Fibonacci
    {
        private readonly List<int> _fibonacci = new List<int>{1, 1};

        public Fibonacci()
        {
        }

        public double Start(double accuracy, double leftPoint, double rightPoint)
        {       
            var previousLenght = rightPoint - leftPoint;
            while(true)
            {
                var newEl = _fibonacci[^2] + _fibonacci[^1];
                _fibonacci.Add(newEl);
                if(newEl > Math.Abs(previousLenght) / accuracy)
                    break;
            }
            
            var n = _fibonacci.Count - 1;
            var leftBorder  = leftPoint + (double)_fibonacci[^3] / _fibonacci[n] * previousLenght;
            var rightBorder = leftPoint + (double)_fibonacci[^2] / _fibonacci[n] * previousLenght;
            var functionLeftBorder  = Function.GetValue(leftBorder);
            var functionRightBorder = Function.GetValue(rightBorder);
            
            while(n > 2)
            {
                n--;
                if (functionLeftBorder < functionRightBorder)
                {
                    rightPoint = rightBorder;
                    rightBorder = leftBorder;
                    functionRightBorder = functionLeftBorder;
                    leftBorder = leftPoint + (rightPoint - rightBorder);
                    functionLeftBorder = Function.GetValue(leftBorder);
                }
                else 
                {
                    leftPoint = leftBorder;
                    leftBorder = rightBorder;
                    functionLeftBorder = functionRightBorder;
                    rightBorder = rightPoint - (leftBorder - leftPoint);
                    functionRightBorder = Function.GetValue(rightBorder);
                }
                    
            }
            
            var finalPoint = (leftPoint + rightPoint) / 2;
            return finalPoint; 
        }
        
    }
}