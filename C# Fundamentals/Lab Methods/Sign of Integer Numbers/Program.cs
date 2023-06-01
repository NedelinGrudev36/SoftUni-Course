using System;
using System.IO;

namespace Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            SingOfNumber(number);
        }

        private static void SingOfNumber(int number)
        {
            if (number == 0) { Console.WriteLine($"The number {number} is zero."); }
            else if (number > 0) { Console.WriteLine($"The number {number} is positive."); }
            else if (number < 0) { Console.WriteLine($"The number {number} is negative."); }
        }


    }
}
