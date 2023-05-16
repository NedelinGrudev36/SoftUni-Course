using System;

namespace Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {


            
            do
            {
                int num = int.Parse(Console.ReadLine());
                if (num%2==0)
                {
                    if (num<0)
                    {
                        num = -num;
                    }
                    Console.WriteLine($"The number is: {num}");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            } while (true);
            
            

        }
    }
}
