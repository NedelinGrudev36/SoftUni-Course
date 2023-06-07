using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            if (numberOne < numberTwo && numberOne < numberThree)
            {
                
                result = num1(numberOne, numberTwo, numberThree);
                Console.WriteLine(result);
            }
            else if (numberTwo < numberOne && numberTwo < numberThree)
            {
               
                result = num2(numberOne, numberTwo, numberThree);
                Console.WriteLine(result);
            }
            else if (numberThree < numberOne && numberThree < numberTwo)
            {

                result = num3(numberOne, numberTwo, numberThree);
                Console.WriteLine(result);
            }             
        }

        static int num1(int numberOne, int numberTwo, int numberThree)
        {
            int result = 0;
            if (numberOne < numberTwo && numberOne < numberThree)
            {
                result = numberOne;
            }
            return result;
        }

        static int num2(int numberOne, int numberTwo, int numberThree)
        {
            int result = 0;
            if (numberTwo < numberOne && numberTwo < numberThree)
            {
                result = numberTwo;
            }
            return result;
        }

        static int num3(int numberOne, int numberTwo, int numberThree)
        {
            int result = 0;
            if (numberThree < numberOne && numberThree < numberTwo)
            {
                result = numberThree;
            }
            return result;
        }
    }
}
