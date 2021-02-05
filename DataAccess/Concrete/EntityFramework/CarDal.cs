using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                var addedEntity = reCapContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                var deleteEntity = reCapContext.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                reCapContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                return reCapContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter=null)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                return filter==null ? reCapContext.Set<Car>().ToList() : reCapContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                var UpdatedEntity = reCapContext.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                reCapContext.SaveChanges();
            }
        }
    }
}