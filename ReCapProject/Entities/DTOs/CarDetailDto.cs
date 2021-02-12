using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string CarDescription { get; set; }
        public string BrandName { get; set; }
        public string CarColor { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
