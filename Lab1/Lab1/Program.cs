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
            double res1 = fib.Start(0.0001, 1, 10);
            double res2 = dichotomy.Start(0.0001, 1, 10);
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            //to be continued
        }
    }
}
