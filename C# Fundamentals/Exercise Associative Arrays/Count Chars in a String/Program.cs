using System;
using System.Collections.Generic;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> countCharacters = new Dictionary<char, int>();
            string line = Console.ReadLine();
            for (int i = 0; i < line.Length; i++)
            {
                if (countCharacters.ContainsKey(line[i]))
                {
                    countCharacters[line[i]]++;
                }
                else
                {
                    countCharacters.Add(line[i], 1);
                }
                //countCharacters.Add(line[0],)
            }
            foreach (var item in countCharacters.Keys)
            {
                Console.WriteLine($"{item} -> {countCharacters[item]}");
            }
        }
    }
}
