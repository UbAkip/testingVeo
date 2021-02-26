using AlmostNetCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmostNetCore.Services.Services
{
    public class MatrixService : IMatrixService
    {
        public int[][] GenerateRandomMatrix(int count)
        {
            int[][] matrix = new int[count][];
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                matrix[i] = new int[count];
                for (int j = 0; j < count; j++)
                {
                    //TODO: can create with custom parameters for random
                    matrix[i][j] = random.Next(0, 99);
                }
            }
            return matrix;
        }
    }
}
