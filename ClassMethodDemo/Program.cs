using System;
using System.Collections.Generic;

namespace ClassMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();

            Console.WriteLine("1. Yeni Müşteri");
            Console.WriteLine("2. Müşteri Güncelle");
            Console.WriteLine("3. Müşteri Sil");
            Console.WriteLine("4. Müşterileri listele");
            Console.WriteLine("***************************************************");

            var answer = Console.ReadLine();

            if (answer == "1")
            {
                Customer customer = new Customer();
                Console.Write("Id Giriniz: ");
                customer.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ad Giriniz: ");
                customer.FirstName = Console.ReadLine();
                Console.Write("Soyad Giriniz: ");
                customer.LastName = Console.ReadLine();

                customerManager.Add(customer);
                var listOfCustomer = customerManager.GetAll();
            }
            else if (answer == "2")
            {
                customerManager.GetAll();
                Customer customer = new Customer();

                Console.Write("Güncellemek istediğiniz müşteriye ait Id Giriniz: ");
                customer.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ad Giriniz: ");
                customer.FirstName = Console.ReadLine();
                Console.Write("Soyad Giriniz: ");
                customer.LastName = Console.ReadLine();

                customerManager.Update(customer);

                var listOfCustomer = customerManager.GetAll();

            }
            else if (answer == "3")
            {
                var listOfCustomer = customerManager.GetAll();
                Customer customer = new Customer();

                Console.Write("Silmek istediğiniz müşteriye ait Id Giriniz: ");
                customer.Id = Convert.ToInt32(Console.ReadLine());
                customerManager.Delete(customer);

                listOfCustomer = customerManager.GetAll();

            }
            else
            {
                var listOfCustomer = customerManager.GetAll();
            }
        }
    }
}
