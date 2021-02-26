using AlmostNetCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmostNetCore.Services.Services
{
    public class FileExecutorFactory : IFileExecutorFactory
    {
        public IExcelFileExecutor CreateExcelFileExecutor()
        {
            return new ExcelFileExecutor();
        }
    }
}
