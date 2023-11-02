namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Bear("Pesho");
            Console.WriteLine($"{animal.Name}");
            Console.WriteLine($"{animal.Name}");
        }
    }
}