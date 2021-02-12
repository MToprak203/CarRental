using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            Console.WriteLine("\n----------------- Results -----------------");
            ResultsTest();
            Console.WriteLine("\n----------------- Rent Test -----------------");
            RentTest();
        }

        private static void RentTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());

            Console.WriteLine(customerManager.Add(new Customer { Id = 1, UserId = 1, CompanyName = "Company1" }).Message);
            Console.WriteLine(customerManager.Add(new Customer { Id = 2, UserId = 2, CompanyName = "Company2" }).Message);
            Console.WriteLine(customerManager.Add(new Customer { Id = 3, UserId = 1, CompanyName = "Company3" }).Message);

            Console.WriteLine(rentalManager.Add(new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = new DateTime(2017 - 10 - 10) }).Message);
            Console.WriteLine(rentalManager.Add(new Rental { Id = 2, CarId = 2, CustomerId = 3, RentDate = new DateTime(2019 - 9 - 8), ReturnDate = DateTime.Now }).Message);
            Console.WriteLine(rentalManager.Add(new Rental { Id = 3, CarId = 1, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = DateTime.Now }).Message);

            Console.WriteLine(userManager.Add(new User { Id = 1, FirstName = "FN1", LastName = "LN1", Email = "Email1", Password = "PW1" }).Message);
            Console.WriteLine(userManager.Add(new User { Id = 2, FirstName = "FN2", LastName = "LN2", Email = "Email2", Password = "PW2" }).Message);
            Console.WriteLine(userManager.Add(new User { Id = 3, FirstName = "FN3", LastName = "LN3", Email = "Email3", Password = "PW3" }).Message);

            Console.WriteLine(colorManager.Add(new Color { Id = 1, Name = "Red" }).Message);
            Console.WriteLine(colorManager.Add(new Color { Id = 2, Name = "Blue" }).Message);

            Console.WriteLine(brandManager.Add(new Brand { Id = 1, Name = "BMW" }).Message);
            Console.WriteLine(brandManager.Add(new Brand { Id = 2, Name = "Tofas" }).Message);

            Console.WriteLine(carManager.Add(new Car { Id = 1, CarName = "XYZ", BrandId = 1, ColorId = 1, DailyPrice = 50, ModelYear = "1999", Description = "X" }).Message);
            Console.WriteLine(carManager.Add(new Car { Id = 2, CarName = "WER", BrandId = 1, ColorId = 2, DailyPrice = 70, ModelYear = "1978", Description = "W" }).Message);
            Console.WriteLine(carManager.Add(new Car { Id = 3, CarName = "TYU", BrandId = 2, ColorId = 1, DailyPrice = 80, ModelYear = "2007", Description = "T" }).Message);

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(userManager.Delete(user).Message);
            }

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rentalManager.Delete(rental).Message);
            }

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customerManager.Delete(customer).Message);
            }

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(colorManager.Delete(color).Message);
            }

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brandManager.Delete(brand).Message);
            }

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(carManager.Delete(car).Message);
            }

            

        }

        private static void ResultsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine(colorManager.Add(new Color { Id = 1, Name = "Red" }).Message);
            Console.WriteLine(colorManager.Add(new Color { Id = 2, Name = "Blue" }).Message);

            Console.WriteLine(brandManager.Add(new Brand { Id = 1, Name = "BMW" }).Message);
            Console.WriteLine(brandManager.Add(new Brand { Id = 2, Name = "Tofas" }).Message);

            Console.WriteLine(carManager.Add(new Car { Id = 1, CarName = "XYZ", BrandId = 1, ColorId = 1, DailyPrice = 50, ModelYear = "1999", Description = "X" }).Message);
            Console.WriteLine(carManager.Add(new Car { Id = 2, CarName = "WER", BrandId = 1, ColorId = 2, DailyPrice = 70, ModelYear = "1978", Description = "W" }).Message);
            Console.WriteLine(carManager.Add(new Car { Id = 3, CarName = "TYU", BrandId = 2, ColorId = 1, DailyPrice = 80, ModelYear = "2007", Description = "T" }).Message);

            Console.WriteLine(carManager.Update(new Car { Id = 1 }).Message);
            Console.WriteLine(brandManager.Update(new Brand { Id = 1 }).Message);
            Console.WriteLine(colorManager.Update(new Color { Id = 1 }).Message);

            var ColorAll = colorManager.GetAll();
            Console.WriteLine(ColorAll.Message);

            foreach (var color in ColorAll.Data)
            {
                Console.WriteLine(colorManager.Delete(color).Message);
            }

            var BrandAll = brandManager.GetAll();
            Console.WriteLine(BrandAll.Message);

            foreach (var brand in BrandAll.Data)
            {
                Console.WriteLine(brandManager.Delete(brand).Message);
            }

            var CarAll = carManager.GetAll();
            Console.WriteLine(CarAll.Message);

            foreach (var car in CarAll.Data)
            {
                Console.WriteLine(carManager.Delete(car).Message);
            }

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

            foreach (var carDetail in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("\nCar Name: " + carDetail.CarName +
                                  "\nBrand Name: " + carDetail.BrandName +
                                  "\nColor Name: " + carDetail.ColorName +
                                  "\nDaily Price: " + carDetail.DailyPrice +
                                  "\n------------------------\n");
            }

            foreach (var color in colorManager.GetAll().Data)
            {
                colorManager.Delete(color);
            }

            foreach (var brand in brandManager.GetAll().Data)
            {
                brandManager.Delete(brand);
            }

            foreach (var car in carManager.GetAll().Data)
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
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine("------------------------\n");
            brandManager.Update(new Brand { Id = 1, Name = "Wolksvagen" });

            Console.WriteLine(brandManager.GetById(1).Data.Name +
                    "\n------------------------\n");

            brandManager.Delete(new Brand { Id = 2, Name = "Tofas" });

            foreach (var brand in brandManager.GetAll().Data)
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
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("------------------------\n");
            carManager.Update(new Car { Id = 1, CarName = "LLL" });

            Console.WriteLine(carManager.GetById(1).Data.CarName +
                    "\n------------------------\n");

            carManager.Delete(new Car { Id = 2 });

            foreach (var car in carManager.GetAll().Data)
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
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }

            Console.WriteLine("------------------------\n");
            colorManager.Update(new Color { Id = 1, Name = "Yellow" });

            Console.WriteLine(colorManager.GetById(1).Data.Name +
                    "\n------------------------\n");

            colorManager.Delete(new Color { Id = 2});

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name +
                    "\n------------------------\n");
                colorManager.Delete(color);
            }
        }
        
    }
}
