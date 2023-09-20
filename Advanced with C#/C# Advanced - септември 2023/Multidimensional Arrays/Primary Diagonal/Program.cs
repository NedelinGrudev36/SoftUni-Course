int number=int.Parse(Console.ReadLine());
    
int rows = number;
int cols = number;
int[,] matrix = new int[rows, cols];
int sum = 0;
for (int i = 0; i <matrix.GetLength(0) ; i++)
{
   sum+= matrix[i,i];
}
Console.WriteLine(sum);