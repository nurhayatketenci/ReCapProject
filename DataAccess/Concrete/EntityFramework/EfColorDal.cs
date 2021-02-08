using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Entities.Concrete.Color entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var addedColor = context.Entry(entity);
                addedColor.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Entities.Concrete.Color entity)
        {

            using (ReCapContext context = new ReCapContext())
            {
                var deletedColor = context.Entry(entity);
                deletedColor.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Entities.Concrete.Color Get(Expression<Func<Entities.Concrete.Color, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Entities.Concrete.Color>().SingleOrDefault(filter);
            }
        }

        public List<Entities.Concrete.Color> GetAll(Expression<Func<Entities.Concrete.Color, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null
                    ? context.Set<Entities.Concrete.Color>().ToList()
                    : context.Set<Entities.Concrete.Color>().Where(filter).ToList();
            }
        }

        public void Update(Entities.Concrete.Color entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedColor = context.Entry(entity);
                updatedColor.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
