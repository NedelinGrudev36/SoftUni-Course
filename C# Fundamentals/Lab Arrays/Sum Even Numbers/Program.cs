using System;
using System.Linq;

namespace Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[] evenNum = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < evenNum.Length; i++)
            {
                if (evenNum[i]%2==0)
                {
                    sum += evenNum[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
