using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentacarContext>, ICarDal
    {
        public List<CarDetailsDTO> GetCarDetails()
        {
            using (RentacarContext context = new RentacarContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands
                             on ca.BrandId equals br.BrandId
                             join cl in context.Colors
                             on ca.ColorId equals cl.ColorId
                             select new CarDetailsDTO
                             {
                                 Id = ca.Id,
                                 BrandName = br.BrandName,
                                 ColarName = cl.ColorName,
                                 DailyPrice = ca.DailyPrice

                             };


             return result.ToList();
            }

        }
    }
}
