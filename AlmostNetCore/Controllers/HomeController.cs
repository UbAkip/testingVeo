using AlmostNetCore.Data.Interfaces;
using ExcelDataReader;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace AlmostNetCore.Controllers
{
    public class HomeController : Controller
    {
        public const string MimeTextCSV = "text/csv";
        private IMatrixService _matrixService;
        public HomeController(IMatrixService matrixService)
        {
            _matrixService = matrixService;
        }

        public ActionResult Index(int[][] matrix)
        {
            return View(matrix);
        }
            
        public ActionResult Getmatrix()
        {
            var matrix = _matrixService.GenerateRandomMatrix(4);

            return View("index", matrix);
        }

        [HttpPost]
        public ActionResult Transform(int[][] matrix, string st)
        {
            if (matrix.Length > 1)
            {
                for (int i = 0; i < matrix.Length / 2; i++)
                {
                    for (int j = i; j < matrix.Length - i - 1; j++)
                    {
                        int top = matrix[i][j];

                        int right = matrix[j][matrix.Length - i - 1];

                        int bot = matrix[matrix.Length - i - 1][matrix.Length - j - 1];

                        int left = matrix[matrix.Length - j - 1][i];


                        matrix[j][matrix.Length - i - 1] = top;
                        matrix[matrix.Length - i - 1][matrix.Length - j - 1] = right;
                        matrix[matrix.Length - j - 1][i] = bot;
                        matrix[i][j] = left;
                    }

                }
            }
            return View("index", matrix);
        }

    }
}