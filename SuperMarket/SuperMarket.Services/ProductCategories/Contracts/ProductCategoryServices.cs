using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductCategories.Contracts
{
    public interface ProductCategoryServices
    {
        public IList<GetAllProductCategoryDto> GetAll();
        public FindByIdProductCategoryDto FindById(int id);
        public void Add(AddProductCategoryDto dto);
        public void Update(int id, UpdateProductCategoryDto dto);
        public void Delete(int id);
    }
}
