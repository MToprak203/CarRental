using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : CrudManager<Car>, ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _entityDal = carDal;
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessfulDataResult<List<Car>>(_entityDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessfulDataResult<List<Car>>(_entityDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessfulDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
