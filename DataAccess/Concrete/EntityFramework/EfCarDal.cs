using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 Images = (from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).ToList(),
                                 CarId = c.CarId,
                                 ColorId = c.ColorId,
                                 ColorName = co.ColorName,
                                 BrandId = c.BrandId,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 FindeksPuan = c.FindeksPuan
                             };


                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}

