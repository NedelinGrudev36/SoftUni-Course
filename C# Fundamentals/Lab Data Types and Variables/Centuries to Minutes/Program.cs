using System;

namespace Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = int.Parse(Console.ReadLine());
            double centuriesCount = 1;
            double yearsCount = 100;
            double daysCount = 36524;
            double hoursCount = 876576;
            double minutesCount = 52594560;
            
            double centuries = input * centuriesCount;
            double years = input * yearsCount;
            double days = input * daysCount;
            double hours = input * hoursCount;
            double minutes = input * minutesCount;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
            double oneYears = 365.2422;

        }
    }
}
