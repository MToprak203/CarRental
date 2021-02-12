using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : CrudManager<Color>, IColorService
    {
        public ColorManager(IColorDal colorDal)
        {
            _entityDal = colorDal;
        }

        
    }
}
