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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CUsersId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join u in context.Users
                             on cu.CUsersId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.CarId,
                                 BrandName = b.BrandName,
                                 CustomerName = cu.CompanyName,
                                 UserName = $"{u.FirstName} {u.LastName}",
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }

        public RentalDetailDto GetRentDetailsById(Expression<Func<RentalDetailDto, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
               
                IQueryable<RentalDetailDto> data = CreateData(context);
  

                return data.FirstOrDefault(filter);
            }
        }
        private static IQueryable<RentalDetailDto> CreateData(ReCapContext context)
        {
            return from rent in context.Rentals
                   join car in context.Cars on rent.CarId equals car.CarId
                   join bra in context.Brands on car.BrandId equals bra.BrandId
                   join cus in context.Customers on rent.CustomerId equals cus.CUsersId
                   join usr in context.Users on cus.CUsersId equals usr.Id
                   select new RentalDetailDto
                   {
                       Id = rent.CarId,
                       BrandName = bra.BrandName,
                       CustomerName = usr.FirstName,
                       RentDate = rent.RentDate,
                       ReturnDate = rent.ReturnDate
                   };
        }


       


    }
}
