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
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context= new RentACarContext()) 
            {
                // var result = from c in context.Cars join b in context.Brands on c.BrandId equals b.BrandId select new CarDetailDto { };
                var result = from c in context.Cars join b in context.Brands on c.BrandId equals b.BrandId join clr in context.Colors on c.ColorId equals clr.ColorId select new CarDetailDto { BrandName = b.Name,CarName=c.Description,ColorName=clr.Name,DailyPrice=c.DailyPrice };                     

                return result.ToList();
            }
            //var result = from b in context.Brands join c in context.Cars on b.Id equals c.BrandId select new BrandDetailDto { };
           // return result.ToList();

            
        }
    }
}
