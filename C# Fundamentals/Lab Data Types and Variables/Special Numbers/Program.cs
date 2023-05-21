using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <=n; i++)
            {
                if (i==5 || i==7 || i==11)
                {
                    Console.WriteLine(i + " -> True");
                }                
                else if (i!= 5 || i != 7 || i != 11)
                {
                    Console.WriteLine(i + " -> False");
                }
                if (counter==n)
                {
                    break;
                }
                
            }
        }
    }
}
