using System;

namespace Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            if (numbers%10==0)
            {
                Console.WriteLine("The number is divisible by 10");
                return;
            }
            if (numbers % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
                return;
            }
            if (numbers % 6 == 0)
            {
                Console.WriteLine("The number is divisible by 6");
                return;
            }
            if (numbers % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
                return;
            }
            if (numbers % 2 == 0)
            {
                Console.WriteLine("The number is divisible by 2");
                return;
            }
            Console.WriteLine("Not divisible");

            
        }
    }
}
