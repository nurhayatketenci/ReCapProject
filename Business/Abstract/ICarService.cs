using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarById(int carId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailBrandById(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailColorById(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailById(int carId);
     
        IDataResult<List<CarDetailDto>> GetCarByBrandAndColorId(int brandId, int colorId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);
      
    }
}
