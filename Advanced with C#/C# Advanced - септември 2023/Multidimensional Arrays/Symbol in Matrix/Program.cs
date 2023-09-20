int n=int.Parse(Console.ReadLine());

int rows = n;
int cols = n;

char[,] text = new char[rows, cols];
for (int row = 0; row < rows; row++)
{
    char[] line = Console.ReadLine().ToArray();
    for (int col = 0; col < cols; col++)
    {
        text[row, col] = line[col];
    }
}
char character=char.Parse(Console.ReadLine());


