using System;

namespace Convert_Meters_to_Kilometerss
{
    class Program
    {
        static void Main(string[] args)
        {
            double oneMeters, result;
            int metersInput = int.Parse(Console.ReadLine());
            
            if (metersInput>1000)
            {
                  oneMeters = 0.001;
                   result = metersInput * oneMeters;
                Console.WriteLine(Math.Round(result, 2));
            }
            if (metersInput<=1000)
            {
                oneMeters = 0.001;
                result = metersInput * oneMeters;
                Console.WriteLine($"{result:f2}");
                //Console.WriteLine(Math.Round(result, 1));
            }
            
            
            //Console.WriteLine($"{result:D2}");
        }
    }
}
