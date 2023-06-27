using System;
using System.Linq;
using System.Collections.Generic;

namespace Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] tokens = line.Split();
                Box oneBox = new Box()
                { 
                    SerialNumber=int.Parse(tokens[0]),
                    Item=new Item()
                    {
                        Name=tokens[1],
                        Price=double.Parse(tokens[3])
                    },
                    ItemQuantity=int.Parse(tokens[2]),
                };
                oneBox.PriceForABox = oneBox.ItemQuantity * oneBox.Item.Price;
                boxes.Add(oneBox);
                line = Console.ReadLine();
            }
            List<Box>sortBox=boxes.OrderByDescending(x => x.PriceForABox).ToList();
            
            foreach (Box currentBox in sortBox)
            {
                Console.WriteLine(currentBox);
            }
            
        }
    }
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Box
    {
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForABox { get; set; }
        public override string ToString()
        {
            string a = string.Empty;
            a += this.SerialNumber + Environment.NewLine;
            a+=$"-- {this.Item.Name} - ${this.Item.Price:f2}: {this.ItemQuantity}" + Environment.NewLine;
            a += $"-- ${this.PriceForABox:f2}";
            return a;
        }
    }
}
