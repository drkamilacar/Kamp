using GameProject.Concrete;
using GameProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Abstract
{
    interface IOrderService
    {
        void Add(Order order);
        void Delete(Order order);
        void Update(Order order);
    }
}
