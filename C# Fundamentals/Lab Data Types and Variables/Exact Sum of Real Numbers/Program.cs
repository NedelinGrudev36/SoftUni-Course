using System;

namespace Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal result = 0;
            int input = int.Parse(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                decimal numbers = decimal.Parse(Console.ReadLine());
                result += numbers;
            }
            Console.WriteLine(result);
        }
    }
}
