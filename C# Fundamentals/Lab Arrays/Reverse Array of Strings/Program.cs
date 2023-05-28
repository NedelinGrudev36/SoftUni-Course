using System;
using System.Linq;

namespace Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] reverseArray = Console.ReadLine()
                .Split()
                .ToArray();
            for (int i = 0; i < reverseArray.Length/2; i++)
            {
                string first = reverseArray[i];
                string last = reverseArray[reverseArray.Length-i-1];
                reverseArray[i] = last;
                reverseArray[reverseArray.Length - i - 1] = first;
            }
            Console.WriteLine(string.Join(" ", reverseArray));
            

        }
    }
}
