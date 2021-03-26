using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;
        private IRentalService _rentalService;
        private ICustomerService _customerService;
        public PaymentManager(IPaymentDal paymentDal, IRentalService rentalService, ICustomerService customerService)
        {
            _paymentDal = paymentDal;
            _rentalService = rentalService;
            _customerService = customerService;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Payment payment)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Payment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
