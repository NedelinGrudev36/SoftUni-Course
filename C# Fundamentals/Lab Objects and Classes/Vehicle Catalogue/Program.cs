using System;
using System.Linq;
using System.Collections.Generic;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Catalog newCatalog = new Catalog();
            while (line!="end")
            {
                string[] tokens = line.Split("/");
                if (tokens[0]=="Car")
                {
                    Car car = new Car();
                    car.Brand = tokens[1];
                    car.Model = tokens[2];
                    car.HorsePower = int.Parse(tokens[3]);
                    newCatalog.Cars.Add(car);
                }
                else if (tokens[0]=="Truck")
                {
                    Truck truck = new Truck();
                    truck.Brand = tokens[1];
                    truck.Model = tokens[2];
                    truck.Weight = double.Parse(tokens[3]);
                    newCatalog.Trucks.Add(truck);
                }
            }

            Console.WriteLine("Cars:");
            foreach (Car oneCar in newCatalog.Cars.OrderByDescending(x => x.Brand))
            {
                Console.WriteLine($"{oneCar.Brand}: {oneCar.Model} - {oneCar.HorsePower}hp");
            }
            Console.WriteLine("Truck:");
            foreach (Truck oneTruck in newCatalog.Trucks.OrderByDescending(x => x.Brand))
            {
                Console.WriteLine($"{oneTruck.Brand}: {oneTruck.Model} - {oneTruck.Weight}kg");
            }


        }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }

}
