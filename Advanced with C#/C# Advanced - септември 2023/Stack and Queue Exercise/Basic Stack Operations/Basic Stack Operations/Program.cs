using System;
using System.Linq;
using System.Collections.Generic;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            int valuesToPush = values[0];
            int valuesToPop = values[1];
            int lookUpValues = values[2];

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < valuesToPush; i++)
            {
                stack.Push(input[1]);
            }

            while (stack.Count>0 && valuesToPop>0)
            {
                stack.Pop();
                valuesToPop--;
            }

            if (stack.Contains(lookUpValues))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count==0)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
