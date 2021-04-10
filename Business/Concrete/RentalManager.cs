using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.Rented);
        }
        public IResult IsDelivered(Rental rental)
        {
            var result = this.GetByCarId(rental.CarId).Data.LastOrDefault();
            if (result == null || result.ReturnDate != default)
                return new SuccessResult();
            return new ErrorResult();

        }
    
        public IResult CheckRentalAvailable(Rental rental)
        {
            //var rental = _rentalDal.Get(r => r.RCarId==carId && r.CustomerId==customerId);
            //var result = _rentalDal.GetAll(r => r.RCarId == rental.RCarId && (r.ReturnDate == null )).Any();
            var result = this.GetByCarId(rental.CarId).Data.LastOrDefault();
            if (!(IsDelivered(rental).Success || (rental.RentDate > result.ReturnDate && rental.RentDate >= DateTime.Now)))
            {
                return new ErrorResult(Messages.CarAlreadyRented);
            }

            return new SuccessResult(Messages.Rented);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ProductDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<RentalDetailDto> GetRentalDetailById(int id)
        {
            var data = _rentalDal.GetRentDetailsById(r => r.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<RentalDetailDto>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<RentalDetailDto>(data, Messages.ProductListed);

        }
        public bool IsCarAvailable(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId && r.ReturnDate == null
                             select r;
                return (result.Count() == 0) ? true : false;
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail(Expression<Func<Rental, bool>> filter = null)
        {

            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var data = _rentalDal.GetRentalDetails();
            if (data == null)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(data, Messages.ProductListed);
        }

        //public bool Rent(int carId)
        //{
        //    using (ReCapContext context = new ReCapContext())
        //    {
        //        var result = from r in context.Rentals
        //                     where r.RCarId == carId && r.ReturnDate == null
        //                     select r;
        //        return (result.Count() == 0) ? true : false;
        //    }
        //}

        public IResult Update(Rental rental)
        {
            return new SuccessResult(Messages.ProductUpdate);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var data = _rentalDal.Get(r => r.RentId == rentalId);
            return new SuccessDataResult<Rental>(data);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            var data = _rentalDal.GetAll(r => r.CarId == carId);
            return new SuccessDataResult<List<Rental>>(data);
        }
    }
}
