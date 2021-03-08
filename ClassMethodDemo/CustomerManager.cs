using System;
using System.Collections.Generic;
using System.Text;

namespace ClassMethodDemo
{
    public class CustomerManager
    {
        List<Customer> _customers;

        public CustomerManager()
        {
            _customers = new List<Customer>
            {
                new Customer{Id=1,FirstName = "Kamil",LastName="Acar"},
                new Customer{Id=2,FirstName = "Emine",LastName="Acar"},
                new Customer{Id=3,FirstName = "Servet Arhan",LastName="Acar"},
                new Customer{Id=4,FirstName = "Arda Baran",LastName="Acar"},
            };
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
            Console.WriteLine("*******************************************************************");
            Console.WriteLine($"Müşteri {customer.FirstName} {customer.LastName} kaydedildi.");
            Console.WriteLine("*******************************************************************");
        }

        public void Update(Customer customer)
        {
            foreach (var c in _customers)
            {
                if (c.Id == customer.Id)
                {
                    c.FirstName = customer.FirstName;
                    c.LastName = customer.LastName;
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine($"Müşteri {customer.FirstName} {customer.LastName} güncellendi.");
                    Console.WriteLine("*******************************************************************");
                    return;
                }
            }
        }

        public void Delete(Customer customer)
        {
            foreach (var c in _customers)
            {
                if (c.Id == customer.Id)
                {
                    _customers.Remove(c);
                    Console.WriteLine("******************************************************************");
                    Console.WriteLine($"Müşteri {customer.FirstName} {customer.LastName} silindi.");
                    Console.WriteLine("******************************************************************");
                    return;
                }
            }
        }

        public List<Customer> GetAll()
        {
            Console.WriteLine("************************** MÜŞTERİ LİSTESİ *************************");
            Console.WriteLine("********************************************************************");

            foreach (var customer in _customers)
            {
                Console.WriteLine($"Müşteri No: {customer.Id} | Müşteri Ad Soyad : {customer.FirstName} {customer.LastName}");
            }
            Console.WriteLine("********************************************************************");
            return _customers;
        }
    }
}
