﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {

        public List<string> Images { get; set; }
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int? FindeksPuan { get; set; }
        public string CarName { get; set; }

    }
}
