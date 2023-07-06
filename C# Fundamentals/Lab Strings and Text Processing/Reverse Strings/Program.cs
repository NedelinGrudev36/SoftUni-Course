using System;
using System.Linq;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static string Reverse(string line)
        {
            string result=string.Empty;
            for (int i = line.Length - 1; i >= 0; i--)
            {
                result += line[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string result = string.Empty;
            while (line!="end")
            {
                string method=Reverse(line);
                result += $"{line} = {method}" + Environment.NewLine;
                line = Console.ReadLine(); 
            }
            Console.WriteLine(result);



            
        }
    }
}
