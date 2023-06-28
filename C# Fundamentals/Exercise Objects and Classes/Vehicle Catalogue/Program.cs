using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class Vehicle
    {
        public string type { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public int power { get; set; }
        public override string ToString()
        {
            return $"Type: {type}\nModel: { brand}\nColor: { color}\nHorsepower: {power}";
        }

        public Vehicle(string type, string brand, string color, int power)
        {
            this.type = type;
            this.brand = brand;
            this.color = color;
            this.power = power;
        }
    }
}
