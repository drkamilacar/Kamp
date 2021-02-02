using GameProject.Abstract;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Concrete
{
    class OrderManager : IOrderService
    {
        public void Add(Order order)
        {
            Console.WriteLine("Sipariş eklendi.");
        }

        public void Delete(Order order)
        {
            Console.WriteLine("Sipariş silindi.");
        }

        public void Update(Order order)
        {
            Console.WriteLine("Sipariş güncellendi.");
        }
    }
}
