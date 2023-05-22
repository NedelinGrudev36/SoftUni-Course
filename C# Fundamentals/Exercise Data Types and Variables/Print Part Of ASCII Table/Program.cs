using System;

namespace Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int stop = int.Parse(Console.ReadLine());
            for (int i = start; i <=stop; i++)
            {
                char characters = (char)i;
                Console.Write(characters + " ");
            }
        }
    }
}
