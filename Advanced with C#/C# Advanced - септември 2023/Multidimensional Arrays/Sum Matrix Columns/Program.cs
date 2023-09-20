﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] separators = { ", " };
            string[] sizes=Console.ReadLine()
                .Split(separators,StringSplitOptions.None);

            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            int[,] matrix= new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
              int sum = 0;
                
                for (int row = 0; row < rows; row++)
                {
                    sum+= matrix[row, col];
                    
                }
                Console.WriteLine(sum);



            }
        }
    }
}
