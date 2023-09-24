string input = Console.ReadLine();
HashSet<string> allPeople = new HashSet<string>();

while(input!="PARTY")
{
   allPeople.Add(input);
    input = Console.ReadLine();
}
while (input!="END")
{
	allPeople.Remove(input);
	input = Console.ReadLine();
}
Console.WriteLine(allPeople.Count);
foreach (string person in allPeople.OrderByDescending(x => char.IsDigit(x[0])))
{
	Console.WriteLine(person);
}
