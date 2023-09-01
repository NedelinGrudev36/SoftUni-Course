using System;
using System.Linq;
using System.Collections.Generic;

namespace Stack_Sum
{
    class Program
    {// Pop - return last value and delete
        // Push - add value
        //Peek - return last value
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> saveNum = new Stack<int>(numbers);
            string[] input = Console.ReadLine().Split();
            input[0] = input[0].ToLower();
            while (input[0]!="end")
            {
                if (input[0]=="add")
                {
                    saveNum.Push(int.Parse(input[1]));
                    saveNum.Push(int.Parse(input[2]));
                }
                else if (input[0]=="remove")
                {
                    if (saveNum.Count>int.Parse(input[1]))
                    {
                        for (int i = 0; i < int.Parse(input[1]); i++)
                        {
                            saveNum.Pop();
                       
                        }

                    }
                }
               input = Console.ReadLine().Split();
              input[0] = input[0].ToLower();

            }
            Console.WriteLine("Sum: " + saveNum.Sum()); 

        }
    }
}
