using System;
using System.Text.RegularExpressions;

namespace BossTitleValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (IsValidInput(input))
                {
                    string bossName = input.Split(':')[0].Trim('|');
                    string title = input.Split(':')[1].Trim('#');

                    int bossNameLength = bossName.Length;
                    int titleLength = title.Length;

                    Console.WriteLine($"{bossName}, The {title}");
                    Console.WriteLine($">> Strength: {bossNameLength}");
                    Console.WriteLine($">> Armor: {titleLength}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }

        static bool IsValidInput(string input)
        {
            string bossNamePattern = @"^\|([A-Z]{4,})\|:#([A-Za-z]+\s[A-Za-z]+)#$";

            Match bossNameMatch = Regex.Match(input, bossNamePattern);

            return bossNameMatch.Success;
        }
    }
}
