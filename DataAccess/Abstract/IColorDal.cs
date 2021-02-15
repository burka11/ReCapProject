using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal:IEntityRepository<Color>
    {
        List<ColorDetailDto> GetColorDetails();
    }
}
