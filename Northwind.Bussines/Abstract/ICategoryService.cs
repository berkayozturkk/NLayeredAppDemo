﻿using Northwind.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussines.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
