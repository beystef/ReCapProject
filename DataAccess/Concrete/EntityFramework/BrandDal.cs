using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class BrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                var addedEntity = reCapContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                var deleteEntity = reCapContext.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                reCapContext.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                return reCapContext.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter=null)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                return filter==null ? reCapContext.Set<Brand>().ToList() : reCapContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
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