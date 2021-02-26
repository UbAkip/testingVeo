using AlmostNetCore.Data.Interfaces;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostNetCore.Services.Services
{
    public class ExcelFileExecutor : IExcelFileExecutor
    {
        public int[][] Load(string text)
        {
            int[][] matrix;
            int columnCount = 0;
            var splitted = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            //O(n)
            foreach (var item in splitted)
            {
                if (string.IsNullOrEmpty(item) || item.Length == 1)
                    continue;

                foreach (var item1 in item.Split(new string[] { ",", ";", "  ", " " }, StringSplitOptions.RemoveEmptyEntries))
                    columnCount++;
                break;
            }

            // skip header in csv
            if (splitted.Length > 0 && splitted[0].Length == 1)
            {
                splitted = splitted.Skip(1).ToArray();
            }
            matrix = new int[columnCount][];
            for (int i = 0; i < splitted.Length; i++)
            {
                matrix[i] = new int[columnCount];
                var splittedColumn = splitted[i].Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < splittedColumn.Length; j++)
                {
                    matrix[i][j] = int.Parse(splittedColumn[j]);
                }
            }

            return matrix;
        }

        public string Save(int[][] matrix)
        {
            if (matrix.Length == 0)
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(";");
            sb.AppendLine();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (j > 0)
                        sb.Append(";");
                    sb.Append(matrix[i][j]);

                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
