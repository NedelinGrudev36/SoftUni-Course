using System;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int product;
            int firstNumbers = int.Parse(Console.ReadLine());
            for (int i = firstNumbers; i <= 10;i++)
            {
                if (i!=firstNumbers)
                {
                    break;
                }
                
                for (int j = 1; j <= 10; j++)
                {
                    product = i * j;
                    Console.WriteLine($"{i} X {j} = {product}");
                }
            }
        }
    }
}
