
using Car_Engine_and_Tires;
Car car;
string command = Console.ReadLine();
int year,horsePower;
double pressure,cubicCapacity;

string[] input;
List<Tire[]> tires = new List<Tire[]>();
List<Engine> engines = new List<Engine>();
List<Car>cars = new List<Car>();
int package = 0;
while (command != "No more tires")
{
    
    year = int.Parse(command.Split()[0]);
    pressure = int.Parse(command.Split()[1]);

    Tire tire1=(new Tire(year, pressure));
    

    command=Console.ReadLine();//1

    year = int.Parse(command.Split()[0]);
    pressure = int.Parse(command.Split()[1]);

    Tire tire2 = (new Tire(year, pressure));


    command = Console.ReadLine();//2

    year = int.Parse(command.Split()[0]);
    pressure = int.Parse(command.Split()[1]);

    Tire tire3 = (new Tire(year, pressure));


    command = Console.ReadLine();//3

    year = int.Parse(command.Split()[0]);
    pressure = int.Parse(command.Split()[1]);

    Tire tire4 = (new Tire(year, pressure));
    tires.Add(new Tire[] {tire1,tire2,tire3,tire4});

    command = Console.ReadLine();//4




}
while (command !="Engines done")
{
    horsePower = int.Parse(command.Split()[0]);
    cubicCapacity = int.Parse(command.Split()[1]);

    engines.Add(new Engine(horsePower, cubicCapacity));

    command = Console.ReadLine();
}


while(command !="Show special")
{
   input = Console.ReadLine().Split().ToArray();
    car = new Car(make: input[0], model: input[1], year: int.Parse(input[2]), fuelQuantity: double.Parse(input[3]), fuelConsumption: int.Parse(input[4]),
        engine: engines[int.Parse(input[5])], tire: tires[int.Parse(input[6])]);
    cars.Add(car);
    
    
    

}
List<Car> specialCars = cars
                .FindAll(c => c.Year >= 2017
                           && c.Engine.HorsePower > 330
                           && c.Tires.Select(t => t.Pressure).Sum() >= 9
                           && c.Tires.Select(t => t.Pressure).Sum() <= 10);

foreach (var output in specialCars)
{
    output.Drive(20);
    Console.WriteLine(output);
}



