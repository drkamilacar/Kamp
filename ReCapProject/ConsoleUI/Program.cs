using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description + " " + car.ModelYear);
            //}

            uint x = 0, y = 1, z;
            for (uint i = 0; i < 85; i++)
            {
                z = x + y;
                Console.WriteLine(z);
                x = y;
                y = z;
            }
        }
    }
}
