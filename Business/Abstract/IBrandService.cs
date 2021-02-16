using Core.Results.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Delete(Brand brnad);
        IResult Update(Brand brand);
        IDataResult<List<Brand>> GetAll();

        IDataResult<List<Brand>> GetBrandsByBrandId(int id);
        IDataResult<List<BrandDetailDto>> GetBrandDetails();
    }
}
