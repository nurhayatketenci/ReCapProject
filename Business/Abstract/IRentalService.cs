using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<RentalDetailDto> GetRentalDetailById(int id);
        IResult CheckRentalAvailable(Rental rental);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetail(Expression<Func<Rental, bool>> filter = null);
        bool IsCarAvailable(int carId);
        IDataResult<Rental> GetById(int rentalId);
        IDataResult <List<Rental>> GetByCarId(int carId);
        IResult IsDelivered(Rental rental);
        IDataResult<List<Rental>> GetRentalsByCarId(int carId);
    }
}
