using System;

namespace Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            uint area = uint.Parse(Console.ReadLine());
            Console.WriteLine($"Town {city} has population of {population} and area {area} square km.");
        }
    }
}
