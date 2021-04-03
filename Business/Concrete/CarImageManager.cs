using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
                IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId), CheckIfImageExtensionValid(file)
               );


            if (result != null)
            {
                return result;
            }

            CarImage carimage = new CarImage
            {
                CarId = carImage.CarId,
                ImagePath = CarImagesHelper.SaveImageFile(file),
                Date = DateTime.Now
            };
            _carImageDal.Add(carimage);
            return new SuccessResult(Messages.CarAdd);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExists(carImage.Id)
                );
            if (result != null)
            {
                return result;
            }
            string path = GetById(carImage.Id).Data.ImagePath;
            CarImagesHelper.DeleteImageFile(path);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult DeleteByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Any())
            {
                foreach (var carImage in result)
                {
                    Delete(carImage);
                }
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarHaveNoImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var result = _carImageDal.Get(ci => ci.Id == carImage.CarId);
            if (result == null) return new ErrorResult(Messages.CarHaveNoImage);
            CarImagesHelper.DeleteImageFile(result.ImagePath);
            result.ImagePath = CarImagesHelper.SaveImageFile(file);
            result.Date = DateTime.Now;
            _carImageDal.Update(result);
            return new SuccessResult(Messages.CarImageUpdated);
     
        }

        private IResult CheckIfImageLimitExpired(int carId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.MaxProduct);
            }
             return new SuccessResult();
        }

        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToLower());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.ImageExtensionInvalid);
            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            string path = Directory.GetCurrentDirectory() + @"\wwwroot\Images\default.png"; 
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            return result;
        }

        private IResult CheckIfImageExists(int id)
        {
            if (_carImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.pictureNotFound);
        }
    }
}
