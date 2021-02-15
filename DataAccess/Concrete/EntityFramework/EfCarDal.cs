﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(car);
                addedEntity.State = EntityState.Added;
                Save(context);
            }
        }
        private static void Save(RentACarContext context)
        {
            context.SaveChanges();
        }

        public void Delete(Car car)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(car);
                deletedEntity.State = EntityState.Deleted;
                Save(context);
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car car)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(car);
                deletedEntity.State = EntityState.Modified;
                Save(context);
            }
        }
    }
}
