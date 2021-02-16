using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarRentalDal:IEntityRepository<CarRental>
    {
        List<CarRentalDetailsDto> GetRentalDetails(Expression<Func<CarRental, bool>> filter = null);
    }
}
