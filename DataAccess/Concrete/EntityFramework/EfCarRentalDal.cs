using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarRentalDal : EfEntityRepositoryBase<CarRental, RentACarContext>, ICarRentalDal
    {
        public List<CarRentalDetailsDto> GetRentalDetails(Expression<Func<CarRental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {

                var result = from rent in context.CarRentals
                             join car in context.Cars on rent.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             join cus in context.Customers on rent.CustomerId equals cus.CustomerId
                             join user in context.Users on cus.UserId equals user.Id
                             select new CarRentalDetailsDto
                             {
                                 Id = rent.Id,
                                 CarName = car.Description,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 CompanyName = cus.CustomerName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate,
                             };
                return result.ToList();
            }
        }
    }
}
