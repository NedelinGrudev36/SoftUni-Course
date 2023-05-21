using System;

namespace Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double pounds = 1.31;
            double result = pounds * input;
            Console.WriteLine($"{result:f3}");


        }
    }
}
