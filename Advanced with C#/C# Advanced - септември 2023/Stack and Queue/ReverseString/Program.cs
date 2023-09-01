using System;
using System.Linq;
using System.Collections.Generic;


namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                st.Push(input[i]);
            }
            foreach (var item in st)
            {
                Console.Write(item);
            }
        }
    }
}
