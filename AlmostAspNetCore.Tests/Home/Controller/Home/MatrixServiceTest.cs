using AlmostNetCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostAspNetCore.Tests.Home.Controller.Classes
{
    public class MatrixServiceTest : IMatrixService
    {
        public static int[][] ExpectedMatrix = new int[4][]
        {
                new int[] {22, 9, 5, 1 },

                new int[] {23, 10, 6, 2 },
                new int[] {24, 11, 7, 3 },
                new int[] {25, 12, 8, 4 }
        };

        public int[][] GenerateRandomMatrix(int count)
        {
            return new int[4][]
            {
                new int[] {1, 2, 3, 4 },
                new int[] {5,6,7,8 },
                new int[] {9,10,11,12 },
                new int[] {22,23,24,25 }
            };
        }
    }
}
