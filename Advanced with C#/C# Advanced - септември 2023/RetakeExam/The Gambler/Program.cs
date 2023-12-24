namespace The_Gambler
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int initialAmount = 100;
            int currentAmount = initialAmount;
            int gamblerRow = -1;
            int gamblerCol = -1;


            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] == 'G')
                    {
                        gamblerRow = i;
                        gamblerCol = j;
                    }


                }
                string command = Console.ReadLine();
                while (command != "end")
                {
                    int newRow = gamblerRow;
                    int newCol = gamblerCol;

                    switch (command)
                    {
                        case "up":
                            newRow--;
                            break;
                        case "down":
                            newRow++;
                            break;
                        case "left":
                            newCol--;
                            break;
                        case "right":
                            newCol++;
                            break;
                    }

                    if (IsOutOfBounds(newRow, newCol, n))
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        return;
                    }

                    char newPosition = matrix[newRow, newCol];
                    matrix[gamblerRow, gamblerCol] = '-';

                    switch (newPosition)
                    {
                        case 'W':
                            currentAmount += 100;
                            break;
                        case 'P':
                            currentAmount -= 200;
                            if (currentAmount <= 0)
                            {
                                Console.WriteLine("End of the game. Total amount: 0$");
                                return;
                            }
                            break;
                        case 'J':
                            Console.WriteLine($"You win the Jackpot!");
                            Console.WriteLine($"End of the game. Total amount: {currentAmount}$");
                            return;
                    }

                    matrix[newRow, newCol] = 'G';
                    gamblerRow = newRow;
                    gamblerCol = newCol;
                    command = Console.ReadLine();
                }
                Console.WriteLine($"End of the game. Total amount: {currentAmount}$");
                PrintMatrix(matrix);
            }

            static bool IsOutOfBounds(int row, int col, int n)
            {
                return row < 0 || row >= n || col < 0 || col >= n;
            }

            static void PrintMatrix(char[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}