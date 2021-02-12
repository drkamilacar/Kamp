using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join u in context.Users
                             on c.UserId equals u.Id
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 CarModel = car.CarModel,
                                 ModelYear = car.ModelYear,
                                 CustomerId = r.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();
            }
        }

        public bool IsCarAtCustomer(int id)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = (from r in context.Rentals
                              where (r.ReturnDate == null && r.CarId == id)
                              orderby r.RentDate descending
                              select new RentalDetailDto
                              {
                                  Id = r.Id,
                                  CarId = r.CarId,
                              }).Take(1);

                if (result.ToList().Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
