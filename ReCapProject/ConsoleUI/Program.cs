using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //EfCarDal carDal = new EfCarDal();
            //CarManager carManager = new CarManager(carDal);
            //GetAllCars(carManager);
            //GetAllBrands(brandManager);
            AddCarDemo(carManager);
            GetCarDetails(carManager);
        }

        private static void GetCarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " | " + car.CarDescription + " | " + car.CarColor + " | " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            };
        }

        private static void GetAllBrands(BrandManager brandManager)
        {
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
        }

        private static void GetAllCars(CarManager carManager)
        {

            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Modeli: " + car.Description + " --- Model Yılı: " + car.ModelYear + " --- Fiyatı: " + car.DailyPrice + " TL");
                }
            }
        }

        private static void AddCarDemo(CarManager carManager)
        {

            var result = carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 2, DailyPrice = 175, ModelYear = 2020, Description = "EGEA DİZEL" });

            Console.WriteLine(result.Message);

        }
    }
}
