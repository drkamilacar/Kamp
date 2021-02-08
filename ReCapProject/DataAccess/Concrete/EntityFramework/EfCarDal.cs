using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public override void Add(Car entity)
        {
            if (entity.Description.Length < 2)
            {
                Console.WriteLine("Araba açıklaması en az 2 karakter uzunluğunda olmalıdır.");
            }
            else if (entity.DailyPrice == 0)
            {
                Console.WriteLine("Arabanın günlük fiyatı sıfır olamaz.");
            }
            else
            {
                base.Add(entity);
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 CarColor = col.ColorDescription,
                                 CarDescription = c.Description,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
