using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 2, DailyPrice = 50000, ModelYear = "2012", Description = "X"},
                new Car{Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 100000, ModelYear = "2017", Description = "Y"},
                new Car{Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 75200, ModelYear = "2016", Description = "Z"},
                new Car{Id = 4, BrandId = 2, ColorId = 3, DailyPrice = 178000, ModelYear = "2019", Description = "T"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car TempCar = (Car)_cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(TempCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            return (Car)_cars.SingleOrDefault(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            Car TempCar = (Car)_cars.Where(c => c.Id == car.Id);
            TempCar.BrandId = car.BrandId;
            TempCar.ColorId = car.ColorId;
            TempCar.DailyPrice = car.DailyPrice;
            TempCar.ModelYear = car.ModelYear;
            TempCar.Description = car.Description;

        }
    }
}
