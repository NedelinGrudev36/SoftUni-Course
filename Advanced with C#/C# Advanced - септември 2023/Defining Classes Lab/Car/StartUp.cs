﻿namespace CarManufacturer
{
    public class StartUp
    {

        static void Main()
        {
            Car car=new Car();

            car.Make = "VM";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");

        }

    }

}