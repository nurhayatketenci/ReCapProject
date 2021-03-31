using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
            var result = _rentalDal.GetAll(r => r.RCarId == rental.RCarId && (r.ReturnDate == null || r.ReturnDate < DateTime.Now)).Any();

            if (result)
            {
                return new ErrorResult(Messages.AlreadyExist);
            }
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.ProductAdded);
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

        public bool Rent()
        {
            return true;
        }

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
            var data = _rentalDal.GetAll(r => r.RCarId == carId);
            return new SuccessDataResult<List<Rental>>(data);
        }
    }
}
