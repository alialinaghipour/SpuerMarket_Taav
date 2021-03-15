﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.Products.Contracts
{
    public class GetByIdProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int WareHouseId { get; set; }
        public int CategoryId { get; set; }

    }
}
