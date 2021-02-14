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
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext ReCap = new ReCapContext())
            {
                var result = from p in ReCap.Cars
                             join c in ReCap.Colors on p.ColorId equals c.ColorId
                             join b in ReCap.Brands on p.BrandId equals b.BrandId
                             select new CarDetailDto { CarId = p.CarId, ColorName = c.ColorName, BrandName = b.BrandName, ModelYear = p.ModelYear };
                return result.ToList();
               
            }
            
        }
    }
}
