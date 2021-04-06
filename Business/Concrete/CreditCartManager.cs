using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CreditCartManager : ICreditCartService
    {
        ICreditCartDal _cartDal;

        public CreditCartManager(ICreditCartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public IResult Add(CreditCart creditCart)
        {
            _cartDal.Add(creditCart);
            return new SuccessResult(Messages.ProductAdded);
        }

     

        public IResult Delete(CreditCart creditCart)
        {
            _cartDal.Delete(creditCart);
            return new SuccessResult(Messages.ProductDelete);
        }

        public IDataResult<List<CreditCart>> GetAll()
        {
            var data = _cartDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<CreditCart>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<CreditCart>>(data, Messages.ProductListed);
        }

        public IDataResult<CreditCart> GetById(int id)
        {
            var data = _cartDal.Get(x => x.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<CreditCart>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<CreditCart>(data, Messages.ProductListed);
        }

        public IDataResult<CreditCart> GetCardByCardNumber(int cardNumber)
        {
            var data = _cartDal.Get(x => x.CardNumber == cardNumber);
            if (data == null)
            {
                return new ErrorDataResult<CreditCart>(data, Messages.ProductNameInvalid);
            }
            return new SuccessDataResult<CreditCart>(data, Messages.ProductListed);
        }
        public IResult CardVerification(CreditCart creditCart)
        {
            var result = _cartDal.Get(c => c.NameOnTheCard == creditCart.NameOnTheCard && c.CardCvv == creditCart.CardCvv && c.ExpirationMonth == c.ExpirationMonth && c.ExpirationYear == c.ExpirationYear);
            if (result==null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            return new SuccessResult(Messages.CardMatched);

        }
        public IResult Update(CreditCart creditCart)
        {
            _cartDal.Update(creditCart);
            return new SuccessResult(Messages.ProductUpdate);
        }
    }
}
