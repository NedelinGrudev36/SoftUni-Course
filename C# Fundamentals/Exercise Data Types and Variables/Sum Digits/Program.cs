using System;
using System.Collections.Generic;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            List<int> saveNumbers = new List<int>();
            int input = int.Parse(Console.ReadLine());
            while (true)
            {
                
                sum += input % 10;
                input /= 10;
                if (input==0)
                {
                    break;
                }
            }
            Console.WriteLine(sum);


            
        
        }
    }
}
