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
            Dichotomy dichotomy = new Dichotomy();
            GoldenSection goldenSection = new GoldenSection();
            double res1 = fib.Start(0.0001, 1, 10);
            double res2 = dichotomy.Start(0.0001, 1, 10);
            double res3 = goldenSection.Start(0.0001, 1, 10);
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.WriteLine(res3);
            //to be continued
        }
    }
}
