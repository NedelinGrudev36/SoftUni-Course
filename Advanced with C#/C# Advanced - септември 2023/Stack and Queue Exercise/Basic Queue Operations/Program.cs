using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Queue_Operations
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
            int lookUpValue = values[2];

            Queue<int> stack = new Queue<int>(input.Take(valuesToPush));

            

            while (stack.Count > 0 && valuesToPop > 0)
            {
                stack.Dequeue();
                valuesToPop--;
            }

            if (stack.Contains(lookUpValue))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
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
