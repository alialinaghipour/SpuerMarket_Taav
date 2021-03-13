using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductCategories.Contracts
{
    public interface ProductCagetoryRepository
    {
        public IEnumerable<GetAllProductCategoryDto> GetAll();
        public FindByIdProductCategoryDto FindById(int id);
        public void Add(ProductCategory category);
        public void Delete(int id);
        public bool IsExistsById(int id);
        public bool IsTitleDuplicate(string title);
    }
}
