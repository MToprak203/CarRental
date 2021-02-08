using Business.Abstract;
using Core.Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : CrudManager<Brand>, IBrandService
    {
        public BrandManager(IBrandDal brandDal)
        {
            _entityDal = brandDal;
        }
    }
}
