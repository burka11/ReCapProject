using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        void Delete(Brand brnad);
        void Update(Brand brand);
        List<Brand> GetAll();

        List<Brand> GetBrandsByBrandId(int id);
        List<BrandDetailDto> GetBrandDetails();
    }
}
