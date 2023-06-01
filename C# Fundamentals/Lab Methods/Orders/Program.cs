using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string item = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;

            switch (item)
            {
                case "coffee":
                    price = coffee(quantity);
                    break;
                case "water":
                    price = water(quantity);
                    break;
                case "coke":
                    price = coke(quantity);
                    break;
                case "snacks":
                    price = snacks(quantity);
                    break;
            }
            Console.WriteLine($"{price:f2}");
        }

        static double snacks(int quantity)
        {
            return quantity * 2.00;
        }

        static double coke(int quantity)
        {
            return quantity * 1.40;
        }

        static double water(int quantity)
        {
            return quantity * 1.0;
        }

        static double coffee(int quantity)
        {
            return quantity * 1.5;
        }
    }
}
