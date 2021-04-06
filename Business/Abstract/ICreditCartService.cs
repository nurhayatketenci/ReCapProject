using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCartService
    {
        IResult Add(CreditCart creditCart);
        IResult Update(CreditCart creditCart);
        IResult Delete(CreditCart creditCart);
        IDataResult<List<CreditCart>> GetAll();
        IDataResult<CreditCart> GetById(int id);
        IResult  CardVerification(CreditCart creditCart);
    }
}
