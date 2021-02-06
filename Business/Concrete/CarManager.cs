using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void AddCar(Car car)
        {
            if (car.Description.Length <= 2 || car.DailyPrice <= 0)
            {
                Console.WriteLine("Car name lenght must be longer than 2. Car Name Lenght: " + car.Description.Length +
                                  "\nCar daily price must be more than 0. Car Daily Price: " + car.DailyPrice + "\n");
                return;
            }
            _carDal.Add(car);
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }
    }
}
