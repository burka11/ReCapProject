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

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => c.BrandId == car.BrandId);
            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.BrandId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsToUpdate = _cars.SingleOrDefault(c => c.BrandId == car.BrandId);
            carsToUpdate.BrandId = car.BrandId;
            carsToUpdate.ColorId = car.ColorId;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.Description = car.Description;
            carsToUpdate.ModelYear = car.ModelYear;
            carsToUpdate.CarId = car.CarId;
        }
    }
}
