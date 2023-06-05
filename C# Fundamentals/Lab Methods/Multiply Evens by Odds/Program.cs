using System;
using System.Linq;

namespace Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            int[] ints = Array.ConvertAll(number.ToString().ToArray(), x => (int)x - 48);


            int even = 0, odd = 0;
            EvenOddSum(ints, ref even, ref odd);

            Console.WriteLine(even * odd);
        }

        static void EvenOddSum(int[] ints, ref int even, ref int odd)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] % 2 != 0)
                {
                    odd += ints[i];
                }
                else
                {
                    even += ints[i];
                }
            }
        }
    }
}
