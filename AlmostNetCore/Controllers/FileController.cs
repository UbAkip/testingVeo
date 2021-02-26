using AlmostNetCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AlmostNetCore.Controllers
{
    public class FileController : Controller
    {
        public const string MimeTextCSV = "text/csv";
        private IFileExecutorFactory _factory;
        public FileController(IFileExecutorFactory factory)
        {
            _factory = factory;
        }

        public ActionResult DowloadFile(int[][] matrix)
        {
            var factory = _factory.CreateExcelFileExecutor();

            string file = factory.Save(matrix);

            return File(new UTF8Encoding().GetBytes(file), MimeTextCSV, "matrix_" + DateTime.Now + ".csv");
        }


        public ActionResult UploadFile(HttpPostedFileBase postedFile)
        {
            //need exception and for postedFile == null and check in frontend.
            if (postedFile == null)
                return View("../home/index", new int[0][] { });
            string extention = Path.GetExtension(postedFile.FileName);
            if (extention != ".csv")
                throw new Exception($"avalable MIME csv");

            string text = new StreamReader(postedFile.InputStream).ReadToEnd();

            int[][] matrix = _factory.CreateExcelFileExecutor().Load(text);

            return View("../home/index", matrix) ;
        }


    }
}