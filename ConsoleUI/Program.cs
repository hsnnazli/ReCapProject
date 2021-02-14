using Business.Concrete;
using Business.Constants;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
            CarTest();
            BrandTest();
            ColorTest();
            CustomerTest();
            UserTest();
            RentalTest();
            Console.ReadLine();


        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.Add(new Rental { CarId = 2, CustomerId = 44, RentDate = DateTime.Now });
            Console.WriteLine("");
            Console.WriteLine("--------------Kiralama Bilgileri--------------");
            //if (result.Success == true)
            //{
                foreach (var rental in rentalManager.GetAll().Data)
                {
                    Console.WriteLine(rental.Id + "-" + rental.CarId + "-" + rental.CustomerId + "-" + rental.RentDate + "-" + rental.ReturnDate);
                }

            //}
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //var result = userManager.Add(new User { FirstName = "Ahmet", LastName = "Can", Email = "ac@ac.com", Password = "54321" });
            Console.WriteLine("");
            Console.WriteLine("--------------Kullanıcı Bilgileri--------------");
            //if (result.Success == true)
            //{
                foreach (var user in userManager.GetAll().Data)
                {
                    Console.WriteLine(user.Id + "-" + user.FirstName + "-" + user.LastName + "-" + user.Email + "-" + user.Password);
                }

            //}

        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //var result = customerManager.Add(new Customer
            //{ UserId = 8, CompanyName = "İnci Oto Kiralama Ltd.Şti" });
            Console.WriteLine("");
            Console.WriteLine("--------------Müşreti Bilgileri--------------");
            //if (result.Success == true)
            //{
                foreach (var customer in customerManager.GetAll().Data)
                {
                    Console.WriteLine(customer.Id + "-" + customer.UserId + "-" + customer.CompanyName);
                }
            //}
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("--------------Color List-------------- ");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + "-" + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("--------------Brand List-------------- ");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "-" + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 670, Description = "otomatik vites", ModelYear = "2019" });
            Console.WriteLine("--------------Car List-------------- ");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Id + "-" + car.BrandName + "-" + car.ColarName + "-" + car.DailyPrice);
            }
        }
    }
}
