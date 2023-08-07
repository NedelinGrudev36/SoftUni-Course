using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] command = input.Split(' ');
            string heroName = command[1];

            switch (command[0])
            {
                case "Enroll":
                    EnrollHero(heroes, heroName);
                    break;
                case "Learn":
                    string spellName = command[2];
                    LearnSpell(heroes, heroName, spellName);
                    break;
                case "Unlearn":
                    spellName = command[2];
                    UnlearnSpell(heroes, heroName, spellName);
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }

        PrintHeroes(heroes);
    }

    static void EnrollHero(Dictionary<string, List<string>> heroes, string heroName)
    {
        if (!heroes.ContainsKey(heroName))
        {
            heroes.Add(heroName, new List<string>());
        }
        else
        {
            Console.WriteLine($"{heroName} is already enrolled.");
        }
    }

    static void LearnSpell(Dictionary<string, List<string>> heroes, string heroName, string spellName)
    {
        if (heroes.ContainsKey(heroName))
        {
            if (!heroes[heroName].Contains(spellName))
            {
                heroes[heroName].Add(spellName);
            }
            else
            {
                Console.WriteLine($"{heroName} has already learnt {spellName}.");
            }
        }
        else
        {
            Console.WriteLine($"{heroName} doesn't exist.");
        }
    }

    static void UnlearnSpell(Dictionary<string, List<string>> heroes, string heroName, string spellName)
    {
        if (heroes.ContainsKey(heroName))
        {
            if (heroes[heroName].Contains(spellName))
            {
                heroes[heroName].Remove(spellName);
            }
            else
            {
                Console.WriteLine($"{heroName} doesn't know {spellName}.");
            }
        }
        else
        {
            Console.WriteLine($"{heroName} doesn't exist.");
        }
    }

    static void PrintHeroes(Dictionary<string, List<string>> heroes)
    {
        Console.WriteLine("Heroes:");

        foreach (var hero in heroes)
        {
            Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
        }
    }
}
