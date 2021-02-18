using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarRentalValidator:AbstractValidator<CarRental>
    {
        private ICarRentalDal _rentalDal;
        public CarRentalValidator()
        {
            _rentalDal = new EfCarRentalDal();
            RuleFor(r => r).Must(Returned).WithMessage("Kiralamak istediğiniz araba henüz teslim edilmedi.");
        }

        private bool Returned(CarRental arg)
        {
            var resultList = _rentalDal.GetAll(r => r.CarId == arg.CarId).ToList();
            var result = resultList.Last().ReturnDate != null ? true : false;
            return result;
        }
    }
}
