using System;

namespace Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input=="A" || input=="B" || input=="C" || input=="D" || input=="E" || input == "F" || input == "G" || input == "H" || input == "I" || input == "J" || input == "K" || input == "L" || input == "M" || input == "N" || input == "O" || input == "P" || input == "Q" || input == "R" || input == "S" || input == "T" || input == "U" || input == "V" || input == "W" || input == "X" || input == "Y" || input == "Z")
            {
                Console.WriteLine("upper-case");
            }
            else if (input == "a" || input == "b" || input == "c" || input == "d" || input == "e" || input == "f" || input == "g" || input == "h" || input == "i" || input == "j" || input == "k" || input == "l" || input == "m" || input == "n" || input == "o" || input == "p" || input == "q" || input == "r" || input == "s" || input == "t" || input == "u" || input == "v" || input == "w" || input == "x" || input == "y" || input == "z")
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
