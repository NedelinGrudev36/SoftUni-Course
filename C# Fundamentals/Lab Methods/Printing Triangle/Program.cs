using System;

namespace Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            TopSaid(number);
            MidSaid(number);
            BotSaid(number);
        }

        static void BotSaid(int number)
        {
            for (int downTriangle = number - 1; downTriangle >= 1; downTriangle--)
            {
                for (int end = 1; end <= downTriangle; end++)
                {
                    Console.Write(end + " ");
                }
                Console.WriteLine();
            }
        }

        static void MidSaid(int number)
        {
            for (int mid = 1; mid <= number; mid++)
            {
                Console.Write(mid + " ");
            }
            Console.WriteLine();
        }

        static void TopSaid(int number)
        {
            for (int upTriangle = 1; upTriangle < number; upTriangle++)
            {
                for (int start = 1; start <= upTriangle; start++)
                {
                    Console.Write(start + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
