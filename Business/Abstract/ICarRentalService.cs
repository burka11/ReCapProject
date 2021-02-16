using Core.Results.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarRentalService
    {
        IResult Add(CarRental rental);
        IResult Delete(CarRental CarRental);
        IResult Update(CarRental CarRental);
        IDataResult<List<CarRental>> GetAll();
        IDataResult<List<CarRentalDetailsDto>> GetCarRentalDetails();
    }
}
