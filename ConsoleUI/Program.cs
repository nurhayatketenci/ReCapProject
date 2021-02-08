using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = "2018", DailyPrice = 145, Descriptions = "Dizel" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice,car.Description);
            }
        }
    }
}
