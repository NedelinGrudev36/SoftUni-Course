using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Engine_and_Tires
{
    class Car
    {
        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        private int horsePower;

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        private double cubicCapacity;

        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }

        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private Tire[] tires;

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }








        public void Drive(double distance)
        {
            if (distance * fuelConsumption > fuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                fuelQuantity -= distance * fuelConsumption;
            }
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.AppendLine($"FuelQuantity: {this.fuelQuantity:f2}");
            return sb.ToString().Trim();
        }
        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        
        public Car(string make,string model,int year,double fuelQuantity,double fuelConsumption,Engine engine, Tire[] tire)
        {
            this.Engine = engine;
            this.Tires = tire;
        }
    }
    
}
