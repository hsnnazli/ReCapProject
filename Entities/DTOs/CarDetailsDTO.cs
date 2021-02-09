using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailsDTO:IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColarName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
