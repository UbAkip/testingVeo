using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlmostNetCore.Data.Interfaces
{
    public interface IFileExecutor
    {
        int[][] Load(string textFile);
        string Save(int[][] matrix);
    }
}
