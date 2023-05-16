using System;
using System.Collections.Generic;

namespace Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0, multiplications =1,saveInput;
            List<int> Digits = new List<int>();
            int input = int.Parse(Console.ReadLine());
            saveInput = input;
            while (input!=0)
            {
                Digits.Add(input % 10);
                input /= 10;


            }
            Console.WriteLine(String.Join(' ',Digits));
            foreach ( var item in Digits)
            {
                if (item==0)
                {
                    multiplications = 1;
                }
                else
                {
                    for (int j = 1; j <= saveInput; j++)
                    {
                        multiplications *= j;
                    }
                }
                
                sum = sum + multiplications;
            }
            if (sum==saveInput)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
                
              
            }
            
            
        }
       
    }
}
