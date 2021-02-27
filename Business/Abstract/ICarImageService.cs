using Core.Utilities.Results.Abstract;
using Entities.Concrete.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService : ICrudService<CarImage>
    {
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
    }
}
