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
            //EfCarDal carDal = new EfCarDal();
            //CarManager carManager = new CarManager(carDal);
            //GetAllCars();
            //GetAllBrands();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + " | " + car.CarDescription + " | " + car.CarColor + " | " + car.DailyPrice);
            }
        }

        private static void GetAllBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carDal.Add(new Car { Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 300, ModelYear = 2018, Description = "a" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Modeli: " + car.Description + " --- Model Yılı: " + car.ModelYear + " --- Fiyatı: " + car.DailyPrice + " TL");
            }
        }
    }
}
