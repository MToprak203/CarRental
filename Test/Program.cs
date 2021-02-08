using Business.Concrete;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Concrete.Properties;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------- Brand CRUD -----------------");
            CrudBrandTest();
            Console.WriteLine("\n----------------- Car CRUD -----------------");
            CrudCarTest();
            Console.WriteLine("\n----------------- Color CRUD -----------------");
            CrudColorTest();
            Console.WriteLine("\n----------------- Car DTO -----------------");
            CarDtoTest();
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { Id = 1, Name = "Red" });
            colorManager.Add(new Color { Id = 2, Name = "Blue" });

            brandManager.Add(new Brand { Id = 1, Name = "BMW" });
            brandManager.Add(new Brand { Id = 2, Name = "Tofas" });

            carManager.Add(new Car { Id = 1, CarName = "XYZ", BrandId = 1, ColorId = 1, DailyPrice = 50, ModelYear = "1999", Description = "X" });
            carManager.Add(new Car { Id = 2, CarName = "WER", BrandId = 1, ColorId = 2, DailyPrice = 70, ModelYear = "1978", Description = "W" });
            carManager.Add(new Car { Id = 3, CarName = "TYU", BrandId = 2, ColorId = 1, DailyPrice = 80, ModelYear = "2007", Description = "T" });

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine("\nCar Name: " + carDetail.CarName +
                                  "\nBrand Name: " + carDetail.BrandName +
                                  "\nColor Name: " + carDetail.ColorName +
                                  "\nDaily Price: " + carDetail.DailyPrice +
                                  "\n------------------------\n");
            }

            foreach (var color in colorManager.GetAll())
            {
                colorManager.Delete(color);
            }

            foreach (var brand in brandManager.GetAll())
            {
                brandManager.Delete(brand);
            }

            foreach (var car in carManager.GetAll())
            {
                carManager.Delete(car);
            }
        }

        static void CrudBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { Id = 1, Name = "BMW" });
            brandManager.Add(new Brand { Id = 2, Name = "Tofas" });

            Console.WriteLine();
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine("------------------------\n");
            brandManager.Update(new Brand { Id = 1, Name = "Wolksvagen" });

            Console.WriteLine(brandManager.GetById(1).Name +
                    "\n------------------------\n");

            brandManager.Delete(new Brand { Id = 2, Name = "Tofas" });

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name +
                    "\n------------------------\n");
                brandManager.Delete(brand);
            }

        }

        static void CrudCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { Id = 1, CarName = "XYZ", BrandId = 1, ColorId = 1, DailyPrice = 50, ModelYear = "1999", Description = "X" });
            carManager.Add(new Car { Id = 2, CarName = "WER", BrandId = 1, ColorId = 2, DailyPrice = 70, ModelYear = "1978", Description = "W" });
            carManager.Add(new Car { Id = 3, CarName = "TYU", BrandId = 2, ColorId = 1, DailyPrice = 80, ModelYear = "2007", Description = "T" });


            Console.WriteLine();
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("------------------------\n");
            carManager.Update(new Car { Id = 1, CarName = "LLL" });

            Console.WriteLine(carManager.GetById(1).CarName +
                    "\n------------------------\n");

            carManager.Delete(new Car { Id = 2 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
                carManager.Delete(car);
            }
            Console.WriteLine("\n------------------------\n");

        }

        static void CrudColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { Id = 1, Name = "Red" });
            colorManager.Add(new Color { Id = 2, Name = "Blue" });

            Console.WriteLine();
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            Console.WriteLine("------------------------\n");
            colorManager.Update(new Color { Id = 1, Name = "Yellow" });

            Console.WriteLine(colorManager.GetById(1).Name +
                    "\n------------------------\n");

            colorManager.Delete(new Color { Id = 2});

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name +
                    "\n------------------------\n");
                colorManager.Delete(color);
            }
        }
        
    }
}
