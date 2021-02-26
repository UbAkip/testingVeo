﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlmostNetCore.Data.Interfaces
{
    public interface IFileExecutorFactory
    {
        IExcelFileExecutor CreateExcelFileExecutor();
    }
}
