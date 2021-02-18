using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Results;
using Core.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarRentalManager : ICarRentalService
    {
        ICarRentalDal _carRentalDal;
        public CarRentalManager(ICarRentalDal carRentalDal)
        {
            _carRentalDal = carRentalDal;
        }

        [ValidationAspect(typeof(CarRentalValidator))]
        public IResult Add(CarRental rental)
        {

            _carRentalDal.Add(rental);

            return new SuccessResult(CarRentalMessages.CarRentAdded);


        }
        public IResult Delete(CarRental CarRental)
        {
            _carRentalDal.Delete(CarRental);
            return new SuccessResult(CarRentalMessages.CarRentDeleted);
        }

        public IDataResult<List<CarRental>> GetAll()
        {
            return new SuccessDataResult<List<CarRental>>(_carRentalDal.GetAll());
        }

        public IDataResult<List<CarRentalDetailsDto>> GetCarRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDetailsDto>>(_carRentalDal.GetRentalDetails());
        }

        public IResult Update(CarRental CarRental)
        {
            if (CarRental.RentDate >= DateTime.Now)
            {
                _carRentalDal.Update(CarRental);
                return new SuccessResult(CarRentalMessages.CarRentUpdated);
            }
            else
            {
                return new ErrorResult(CarRentalMessages.CarRentNameInvalid);
            }
        }
    }
}
