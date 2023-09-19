using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Queue<string> names = new Queue<string>();
            string command = Console.ReadLine();

            while (command!="End")
            {
                

                if (command=="Paid")
                {
                    while (names.Count>0)
                    {
                        Console.WriteLine(names.Dequeue()); 

                    }
                    
                    
                }
                else
                {
                    names.Enqueue(command);
                }
                command = Console.ReadLine();

            }
            Console.WriteLine(names.Count + " people remaining.");
        }
    }
}
