using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();
            Queue<int> result = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                
                if (queue.Peek()%2==0)
                {
                    result.Enqueue(queue.Dequeue());
                }
                else
                {
                    queue.Dequeue();
                }
            }
            Console.WriteLine(string.Join(", ",result));
            



        }
    }
}
