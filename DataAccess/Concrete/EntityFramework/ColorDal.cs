using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                var addedEntity = reCapContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                reCapContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                var deleteEntity = reCapContext.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                reCapContext.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                return reCapContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter=null)
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                return filter==null ? reCapContext.Set<Color>().ToList() : reCapContext.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
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