using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordRemove = Console.ReadLine();
            string line = Console.ReadLine();
            string result = string.Empty;
            while (line.Contains(wordRemove))
            {
                int index = line.IndexOf(wordRemove);
                line = line.Remove(index, wordRemove.Length);

            }
            Console.WriteLine(line);
        }
    }
}
