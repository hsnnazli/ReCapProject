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
            

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + "-" + car.BrandName + "-" + car.ColarName + "-" +car.DailyPrice);
            }
            Console.ReadLine();


        }
    }
}
