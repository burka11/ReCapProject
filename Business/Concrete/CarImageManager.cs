﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Results;
using Core.Results.Abstract;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [SecuredOperation("carimage.add,moderator,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
              CheckIfImageLimit(carImage.CarId)
              );

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(carImage);

            return new SuccessResult();
        }

        [SecuredOperation("carimage.delete,moderator,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        [SecuredOperation("carimage.update,moderator,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int CarId)
        {
            try
            {
                string path = @"\Images\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == CarId).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = CarId, ImagePath = path });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == CarId));
        }
        private IResult CheckIfImageLimit(int CarId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == CarId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(CarImageMessages.FailAddedImageLimit);
            }

            return new SuccessResult();
        }

    }
}
