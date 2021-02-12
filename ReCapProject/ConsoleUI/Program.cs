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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //EfCarDal carDal = new EfCarDal();
            //CarManager carManager = new CarManager(carDal);
            //GetAllCars(carManager);
            //GetAllBrands(brandManager);
            //AddCarDemo(carManager);
            //GetCarDetails(carManager);
            GetCustomerDetails(customerManager);
            //SaveUser(userManager, customerManager);
        }

        private static void SaveUser(UserManager userManager, CustomerManager customerManager)
        {
            User user = new User();

            Console.Write("Kullanıcı adını girin : ");
            user.FirstName = Console.ReadLine();
            Console.Write("Kullanıcı soyadını girin : ");
            user.LastName = Console.ReadLine();
            Console.Write("Kullanıcı Eposta adresini girin : ");
            user.Email = Console.ReadLine();
            Console.Write("Kullanıcı parolasını girin : ");
            user.Password = Console.ReadLine();

            var result = userManager.Add(user);
            if (result.Success)
            {
                Console.WriteLine("**********");
                Console.WriteLine(result.Message);
                Console.WriteLine("**********");
                Console.WriteLine();
            }

            bool isUserEvenACustomer;
            Console.Write("Kullanıcı aynı zamanda müşteri midir? (E/H) : ");
            var yesNoString = Console.ReadLine();
            isUserEvenACustomer = (yesNoString == "E" || yesNoString == "e" ? true : false);
            if (isUserEvenACustomer == true)
            {
                Customer customer = new Customer();
                var savedUserId = userManager.GetUserId(user);
                customer.UserId = savedUserId.Data;
                Console.Write("Müşteri firma adını girin : ");
                customer.CompanyName = Console.ReadLine();

                result = customerManager.Add(customer);
                if (result.Success)
                {
                    Console.WriteLine("**********");
                    Console.WriteLine(result.Message);
                    Console.WriteLine("**********");
                    Console.WriteLine();
                }
            }
        }

        private static void GetCustomerDetails(CustomerManager customerManager)
        {
            var result = customerManager.GetCustomerDetails();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.FirstName + " " + customer.LastName + " | " + customer.Email + " | " + customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            };
        }

        private static void GetCarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " | " + car.CarModel + " | " + car.CarDescription + " | " + car.CarColor + " | " + car.DailyPrice);
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
                var i = 0;
                foreach (var car in result.Data)
                {
                    i = i + 1;
                    Console.WriteLine(i + ".Araç : " + car.CarModel + " --- " + car.Description + " --- Model Yılı: " + car.ModelYear + " --- Fiyatı: " + car.DailyPrice + " TL");
                }
            }
        }

        private static void AddCarDemo(CarManager carManager)
        {

            var result = carManager.Add(new Car { Id = 5, CarModel = "E", BrandId = 3, ColorId = 2, DailyPrice = 175, ModelYear = 2020, Description = "DİZEL, OTOMATİK" });

            Console.WriteLine(result.Message);

        }
    }
}
