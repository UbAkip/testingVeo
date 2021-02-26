using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlmostNetCore.Data.Interfaces
{
    public interface IMatrixService 
    {
        /// <summary>
        /// generate matrix with custom size.
        /// </summary>
        ///
        /// <param name="count">Your size for matrix</param>
        ///
        int[][] GenerateRandomMatrix(int count);
    }
}
