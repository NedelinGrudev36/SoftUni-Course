namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           RandomList list = new RandomList();

            list.Add("1");
            list.Add("45");
            list.Add("3");
            list.Add("67");
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}