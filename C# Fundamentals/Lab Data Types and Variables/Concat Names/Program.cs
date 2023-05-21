using System;

namespace Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string symbol = Console.ReadLine();
            Console.WriteLine(firstName + symbol + secondName);
            //if (symbol == "->")
            //{
            //    Console.WriteLine(firstName + "->" + secondName);
            //}
            //else if (symbol=="<->")
            //{
            //    Console.WriteLine(firstName + "<->" + secondName);
            //}
            //else if (symbol=="=>")
            //{
            //    Console.WriteLine(firstName + "=>" + secondName);
            //}
        }
    }
}
