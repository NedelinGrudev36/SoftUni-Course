using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> saveOutput = new List<string>();
        string inputString = Console.ReadLine();
        string command = Console.ReadLine();

        while (command != "Done")
        {
            string[] commandParts = command.Split();

            switch (commandParts[0])
            {
                case "Change":
                    char charToReplace = char.Parse(commandParts[1]);
                    char replacement = char.Parse(commandParts[2]);
                    inputString = inputString.Replace(charToReplace, replacement);
                    Console.WriteLine(inputString);
                    break;

                case "Includes":
                    string substring = commandParts[1];
                    bool includes = inputString.Contains(substring);
                    Console.WriteLine(includes);
                    break;

                case "End":
                    string endSubstring = commandParts[1];
                    bool endsWith = inputString.EndsWith(endSubstring);
                    Console.WriteLine(endsWith);
                    break;

                case "Uppercase":
                    inputString = inputString.ToUpper();
                    Console.WriteLine(inputString);
                    break;

                case "FindIndex":
                    char charToFind = char.Parse(commandParts[1]);
                    int index = inputString.IndexOf(charToFind);
                    Console.WriteLine(index);
                    break;

                case "Cut":
                    int startIndex = int.Parse(commandParts[1]);
                    int count = int.Parse(commandParts[2]);
                    string cutChars = inputString.Substring(startIndex, count);
                    Console.WriteLine(cutChars);
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }

            command = Console.ReadLine();
        }
    }
}

