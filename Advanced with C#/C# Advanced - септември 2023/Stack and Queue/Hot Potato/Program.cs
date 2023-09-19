using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split().ToArray();
            int input = int.Parse(Console.ReadLine());
            Queue<string> children = new Queue<string>(kids);

            while (children.Count>1)
            {
                for (int i = 1; i < input; i++)
                {
                    children.Dequeue();
                }
            }
        }
    }
}
