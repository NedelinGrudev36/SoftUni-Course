namespace CarManufacturer
{
    public class StartUp
    {

        static void Main()
        {
            string make=Console.ReadLine();
            string model=Console.ReadLine();
            int year=int.Parse(Console.ReadLine());
            int fuelQuantity=int.Parse(Console.ReadLine());    
            int fuelConsumption = int.Parse(Console.ReadLine());    

            Car car = new Car();
            Car carSecond = new Car(make,model,year);
            Car carThird = new Car(make,model,year,fuelQuantity,fuelConsumption);
            
            

        


        }


    }

}