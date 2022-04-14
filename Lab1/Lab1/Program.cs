using System;
using Lab1.Optimization_Methods;

namespace Lab1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Function func = new Function();
            Fibonacci fib = new Fibonacci();
            Parabola par = new Parabola();
            Dichotomy dichotomy = new Dichotomy();
            double res1 = fib.Start(0.0001, 1, 10);
            double res2 = dichotomy.Start(0.0001, 1, 10);
            double res3 = par.Start(0.0001, 1, 10);
            Console.WriteLine(res1);
            Console.WriteLine(Function.GetValue(res1));
            Console.WriteLine(res2);
            Console.WriteLine(Function.GetValue(res2));
            Console.WriteLine(res3);
            Console.WriteLine(Function.GetValue(res3));
            //to be continued
        }
    }
}
