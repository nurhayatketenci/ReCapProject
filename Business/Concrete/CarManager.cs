using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDelete);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }


        public IDataResult<List<CarDetailDto>> GetCarDetailBrandById(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId));

        }

        public IDataResult<List<CarDetailDto>> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailColorById(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductUpdate);
        }
        public IDataResult<List<CarDetailDto>> GetCarByBrandAndColorId(int brandId, int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.ProductNameInvalid);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.ProductListed);
            }

        }

    }
}
