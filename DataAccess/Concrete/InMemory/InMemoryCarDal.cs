using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100,Description="dizel",ModelYear=2018},
            new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=200,Description="otomatik",ModelYear=2019},
            new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=50,Description="dizel",ModelYear=2015},
           

   };
            _brands = new List<Brand> {
            new Brand{BrandId=1,BrandName="Tesla"},
            new Brand{BrandId=2,BrandName="Audi"},
             new Brand{BrandId=3,BrandName="Opel"},

            };
            _colors = new List<Color> {
            new Color{ColorId=1,ColorName="red"},
            new Color{ColorId=2,ColorName="black"},
             new Color{ColorId=3,ColorName="blue"},

            };
        }
            public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            CarToUpdate.CarId = car.CarId;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.Description = car.Description;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.BrandId = car.BrandId;
           
        }
    }
}
