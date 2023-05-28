using System;
using System.Linq;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] realNumbers = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToArray();
            for (int i = 0; i < realNumbers.Length; i++)
            {
                Console.WriteLine($"{realNumbers[i]} => {(int)Math.Round(realNumbers[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
