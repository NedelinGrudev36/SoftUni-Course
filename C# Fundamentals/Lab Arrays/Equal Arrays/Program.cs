using System;
using System.Linq;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int[] firstArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i]==secondArray[i])
                {
                    sum += firstArray[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are identical. Sum: {sum}");
                    
                }
            }
            
            


        }
    }
}
