using System;

namespace Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int product;
            int firstNumbers = int.Parse(Console.ReadLine());
            int secondNumbers = int.Parse(Console.ReadLine());
            for (int i = firstNumbers; i <= 10; i++)
            {
                if (i != firstNumbers)
                {
                    break;
                }

                for (int j = secondNumbers; j <= 10; j++)
                {
                    product = i * j;
                    Console.WriteLine($"{i} X {j} = {product}");
                }
            }
            if (secondNumbers>10)
            {
                int productF = firstNumbers * secondNumbers;
                Console.WriteLine($"{firstNumbers} X {secondNumbers} = {productF}");
            }
        }
    }
}
