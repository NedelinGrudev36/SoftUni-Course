using System;
using System.Linq;

namespace Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int even = 0;
            int odd = 0;
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]%2==0)
                {
                    even += numbers[i];
                }
                else 
                {
                    odd += numbers[i];
                }
            }
            int result = even - odd;
            Console.WriteLine(result);
        }
    }
}
