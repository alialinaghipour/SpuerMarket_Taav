﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductCategories.Contracts
{
    public interface ProductCategoryServices
    {
        public IEnumerable<GetAllProductCategoryDto> GetAll();
        public FindByIdProductCategoryDto FindById(int id);
        public void Add(AddProductCategoryDto dto);
        public void Update(UpdateProductCategoryDto dto);
        public void Delete(int id);
    }
}
