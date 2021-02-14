using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //Carİnsert(carManager, brandManager, colorManager);
            GetDetails();
            GetId(carManager,brandManager,colorManager);

        }


        private static void GetId(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Enter car id:");
            int selection = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("***********************************");
            carManager.GetCarById(selection);
            Car carById = carManager.GetCarById(selection).Data;
            Brand brand = brandManager.GetById(selection).Data;
            Color color = colorManager.GetCarsByColorId(selection).Data;
            Console.WriteLine(selection+"-Brand-"+brand.BrandName+"-Color-"+color.ColorName+"-DailyPrice-"+carById.DailyPrice);
        }

        public static void GetDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandName + "/" + car.ColorName);
            }
        }
    }
}
