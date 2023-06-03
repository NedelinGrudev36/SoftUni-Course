using System;

namespace Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseNum = double.Parse(Console.ReadLine());
           double power = double.Parse(Console.ReadLine());
         double result = 0;
             result = RaiseToPower(baseNum, power,result);
            Console.WriteLine(result);

        }
         static double RaiseToPower(double baseNum,double power,double result)
         {

            result += baseNum;
            for (int i = 1; i <power; i++)
            {
                result *= baseNum;
            }
            
            return result;
         }
    }
}
