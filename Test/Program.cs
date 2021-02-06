using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.AddCar(new Car { Id = 1, BrandId = 1, ColorId = 2, DailyPrice = 5, ModelYear = "2012", Description = "Xzt" });
            carManager.AddCar(new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 0, ModelYear = "2017", Description = "Yxt" });
            carManager.AddCar(new Car { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 12, ModelYear = "2016", Description = "Z" });
            carManager.AddCar(new Car { Id = 4, BrandId = 2, ColorId = 3, DailyPrice = 17, ModelYear = "2019", Description = "Tzx" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
