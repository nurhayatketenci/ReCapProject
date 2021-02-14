using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
    
        public class CarManager : ICarService
        {
            ICarDal _carDal;

            public CarManager(ICarDal carDal)
            {
                _carDal = carDal;
            }


            public IResult Add(Car car)
            {
                if (!(car.Description.Length >= 2 && car.DailyPrice > 0))
                {
                    return new ErrorResult(Messages.ProductNameInvalid);
                }
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }

        

        public IResult Delete(Car car)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.ProductDelete);
            }
            public IResult Update(Car car)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.ProductUpdate);
            }

            public IDataResult<List<Car>> GetAll()
            {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

            public IDataResult<Car> GetCarById(int carId)
            {
                return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
            }

            public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
            }

            public IDataResult<List<Car>> GetCarsByColorId(int colarId)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colarId));
            }
            public IDataResult<List<CarDetailDto>> GetCarDetails()
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            }
            public IDataResult<List<Car>> GetAllByModelYear(int year)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == year));
            }
        }
    }
