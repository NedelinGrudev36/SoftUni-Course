using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i <input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    for (int k = 0; k <input; k++)
                    {
                        Console.Write((char)('a' + i));
                        Console.Write((char)('a' + j));
                        Console.Write((char)('a' + k));
                        Console.WriteLine();
                    }                    
                }
            }
            
            

        }
    }
}
