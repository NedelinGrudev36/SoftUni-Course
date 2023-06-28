using System;
using System.Collections.Generic;
using System.Linq;

namespace Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Phrases = new List<string>() {"Excellent product.",
                "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", 
                "I can't live without this product."};
            List<string> Events = new List<string>()  {"Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feelawesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"};
            List<string> Authors = new List<string>() { "Diana", "Petya", "Stella",
                "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> Cities = new List<string>() { "Burgas", "Sofia", 
                "Plovdiv", "Varna", "Ruse" };
            int input = int.Parse(Console.ReadLine());
            Random random = new Random();
            for (int i = 0; i < input; i++)
            {
                Console.WriteLine($"{Phrases[random.Next(Phrases.Count-1)]} {Events[random.Next(Phrases.Count - 1)]} {Authors[random.Next(Phrases.Count - 1)]} - {Cities[random.Next(Phrases.Count - 1)]}.");
            }
        }
    }
}
