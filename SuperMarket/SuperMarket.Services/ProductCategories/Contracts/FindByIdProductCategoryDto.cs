using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductCategories.Contracts
{
    public class FindByIdProductCategoryDto
    {
        public int Id { get; set; }
        public string Tilte { get; set; }
    }
}
