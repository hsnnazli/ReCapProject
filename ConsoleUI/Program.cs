using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
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
            Console.WriteLine("--------------Car List-------------- ");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + "-" + car.BrandName + "-" + car.ColarName + "-" +car.DailyPrice);
            }
            Console.WriteLine("--------------Brand List-------------- ");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId +"-" + brand.BrandName);
            }
            Console.WriteLine("--------------Color List-------------- ");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId+ "-" + color.ColorName);
            }
            Console.ReadLine();


        }
    }
}
