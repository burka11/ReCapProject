using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context= new RentACarContext()) 
            {
                // var result = from c in context.Cars join b in context.Brands on c.BrandId equals b.BrandId select new CarDetailDto { };
                var result = from c in context.Cars /*== null ? context.Cars : context.Cars.Where(filter)*/
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                     CarId = c.CarId,
                                     BrandName = b.Name,
                                     ColorName = co.Name,
                                     DailyPrice = c.DailyPrice,
                                     Descriptions = c.Description,
                                     ModelYear = c.ModelYear
                                    
                             };
                return result.ToList();

            }
            //var result = from b in context.Brands join c in context.Cars on b.Id equals c.BrandId select new BrandDetailDto { };
           // return result.ToList();

            
        }
    }
}
