using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal capital = decimal.Parse(Console.ReadLine());
            decimal totalPrice = 0m;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${totalPrice:f2}. Remaining: ${capital:f2}");
                    break;
                }
                else if (input == "OutFall 4")
                {
                    if (capital >= 39.99m)
                    {
                        capital -= 39.99m;
                        totalPrice += 39.99m;
                        Console.WriteLine("Bought OutFall 4");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    if (capital >= 39.99m)
                    {
                        capital -= 39.99m;
                        totalPrice += 39.99m;
                        Console.WriteLine("Bought RoverWatch Origins Edition");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "CS: OG")
                {
                    if (capital >= 15.99m)
                    {
                        capital -= 15.99m;
                        totalPrice += 15.99m;
                        Console.WriteLine("Bought CS: OG");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "Zplinter Zell")
                {
                    if (capital >= 19.99m)
                    {
                        capital -= 19.99m;
                        totalPrice += 19.99m;
                        Console.WriteLine("Bought Zplinter Zell");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "Honored 2")
                {
                    if (capital >= 59.99m)
                    {
                        capital -= 59.99m;
                        totalPrice += 59.99m;
                        Console.WriteLine("Bought Honored 2");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "RoverWatch")
                {
                    if (capital >= 29.99m)
                    {
                        capital -= 29.99m;
                        totalPrice += 29.99m;
                        Console.WriteLine("Bought RoverWatch");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                if (capital == 0) { Console.WriteLine("Out of money!"); break; }
            }
        }
    }
}
