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

                var result = from r in filter == null ? context.CarRentals : context.CarRentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new CarRentalDetailsDto
                             {
                                 RentalId = r.RentalId,
                                 CarName = b.Name,
                                 CustomerName = cu.CustomerName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
