int count = int.Parse(Console.ReadLine());
HashSet<string> names = new HashSet<string>();
for (int i = 0; i < count; i++)
{
    string name=Console.ReadLine();
    if (!names.Contains(name))
    {
        names.Add(name);
    }
}
foreach (string item in names)
{
    Console.WriteLine(item);
}
