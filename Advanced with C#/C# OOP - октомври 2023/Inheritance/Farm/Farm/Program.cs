namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            new Dog().Eat();
            new Dog().Bark();

            new Cat().Eat();
            new Cat().Meow();

        }
    }
}