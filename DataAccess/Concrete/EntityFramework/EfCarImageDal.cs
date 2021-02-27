using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, MyCarsContext>, ICarImageDal
    {
        public List<CarImage> GetDefaultImage()
        {
            var defaultImage = new List<CarImage>
            {
                new CarImage
                {
                    CarId = -1, Id = 0, Name="Default", Date=null, ImagePath=@"CarImages\default.png"
                }
            };
            return defaultImage;
        }
    }
}
