﻿using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, MyCarsContext>, IBrandDal
    {
    }
}
