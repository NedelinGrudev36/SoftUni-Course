string input = Console.ReadLine();

HashSet<string> parking = new HashSet<string>();
while (input!="END")
{
    string direction = input.Split(", ")[0];
    string carNumber = input.Split(", ")[1];

    if (direction=="IN")
    {
        parking.Add(carNumber);
    }
    else
    {
        parking.Remove(carNumber); 
    }


    input = Console.ReadLine();
}
if (parking.Count<=0)
{
    Console.WriteLine("Parking Lot is Empty");
}
foreach (string item in parking)
{
    Console.WriteLine(item);
}
