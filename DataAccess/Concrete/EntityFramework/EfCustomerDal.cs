using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {

            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers join u in context.Users on c.CUsersId equals u.Id select new CustomerDetailDto { Id = c.CUsersId, FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName,FindexPuan=c.FindexPuan };
                return result.ToList();

            }
        }
    }
}
