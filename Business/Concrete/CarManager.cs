using Business.Abstract;
using Core.Business.Concrete;
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

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _entityDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _entityDal.GetAll(c => c.BrandId == brandId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
