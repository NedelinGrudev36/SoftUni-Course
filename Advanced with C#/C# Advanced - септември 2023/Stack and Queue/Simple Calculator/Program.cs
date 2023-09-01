using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] num = Console.ReadLine()
                .Split();

            Stack<string> saveNum = new Stack<string>(num.Reverse());
            int result = 0;

            //int number = int.Parse(saveNum.Pop());
            //string sign = saveNum.Pop();
            while (saveNum.Any())
            {
                int number = int.Parse(saveNum.Pop());
                string sign = saveNum.Pop();
                if (sign=="+")
                {
                    result += number;
                }
                else if (sign=="-")
                {
                    result -= number;
                }

                

            }
            Console.WriteLine(result);
            
            

        }
    }
}
