using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            // number of people
            int n = int.Parse(Console.ReadLine());
            //capacity of the elevator
            int p = int.Parse(Console.ReadLine());
            int courses = n / p;
            if (n%p>0)
            {
                int waits = n % p;
                courses++;
            }
            Console.WriteLine(courses);

            
        }
    }
}
