using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=650,Description="BMW 530i",ModelYear=2018},
                 new Car{CarId=1,BrandId=1,ColorId=2,DailyPrice=800,Description="BMW 740Li",ModelYear=2020},
                 new Car{CarId=2,BrandId=2,ColorId=1,DailyPrice=150,Description="Peugeot 301",ModelYear=2016},
                  new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=600,Description="Mercedes-Benz E180",ModelYear=2017},
                   new Car{CarId=4,BrandId=4,ColorId=3,DailyPrice=300,Description="Peugeot 3008",ModelYear=2018},
            };

        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => c.BrandId == entity.BrandId);
            _cars.Remove(entity);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            Car carsToUpdate = _cars.SingleOrDefault(c => c.BrandId == entity.BrandId);
            carsToUpdate.BrandId = entity.BrandId;
            carsToUpdate.ColorId = entity.ColorId;
            carsToUpdate.DailyPrice = entity.DailyPrice;
            carsToUpdate.Description = entity.Description;
            carsToUpdate.ModelYear = entity.ModelYear;
            carsToUpdate.CarId = entity.CarId;
        }


    }
}
