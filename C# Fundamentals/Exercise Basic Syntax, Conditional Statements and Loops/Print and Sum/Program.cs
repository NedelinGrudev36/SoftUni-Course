using System;

namespace Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
                sum = sum + i;
                
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
            
        }
    }
}
