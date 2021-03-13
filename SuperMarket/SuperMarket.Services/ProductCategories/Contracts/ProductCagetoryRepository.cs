using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductCategories.Contracts
{
    public interface ProductCagetoryRepository
    {
        public IList<GetAllProductCategoryDto> GetAll();
        public FindByIdProductCategoryDto GetById(int id);
        public ProductCategory FindById(int id);
        public void Add(ProductCategory category);
        public void Delete(ProductCategory category);
        public bool IsExistsById(int id);
        public bool IsTitleDuplicate(string title);
    }
}
