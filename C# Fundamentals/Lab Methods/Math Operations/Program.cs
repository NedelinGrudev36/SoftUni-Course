
using System;

namespace Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberA = int.Parse(Console.ReadLine());
            string a = Console.ReadLine();
            int numberB = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculator(numberA, a, numberB));

        }

        static double Calculator(int numberA, string a, int numberB)
        {
            double result = 0;
            if (a == "/")
            {
                result = numberA / numberB;
            }
            else if (a == "*")
            {
                result = numberA * numberB;
            }
            else if (a == "+")
            {
                result = numberA + numberB;
            }
            else if (a == "-")
            {
                result = numberA - numberB;
            }

            return result;
        }
    }
}
