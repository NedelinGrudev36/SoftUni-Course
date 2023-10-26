namespace DefiningClasses
{
    public class StrtUp
    {
        static void Main()
        {
            Person person = new Person();
            person.Name = "Peter";
            person.Age = 20;
            Console.WriteLine($"{person.Name}: {person.Age}");
        }
    }
}


