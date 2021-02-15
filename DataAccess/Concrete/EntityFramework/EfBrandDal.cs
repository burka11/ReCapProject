using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand,RentACarContext>,IBrandDal
    {
        public List<BrandDetailDto> GetBrandDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                //var result =from p in context.Products join c in context.Categories on p.CategoryId equals c.CategoryId select new ProductDetailDto {ProductId=p.ProductId,ProductName=p.ProductName,CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock };
                var result = from b in context.Brands join c in context.Cars on b.Id equals c.BrandId select new BrandDetailDto { };
                return result.ToList();
            }
        }
    }
}
