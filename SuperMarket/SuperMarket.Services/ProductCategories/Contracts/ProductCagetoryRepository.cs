using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.ProductCategories.Contracts
{
    public interface ProductCagetoryRepository
    {
        public Task<IList<GetAllProductCategoryDto>> GetAll();
        public Task<FindByIdProductCategoryDto> GetById(int id);
        public Task<ProductCategory> FindById(int id);
        public void Add(ProductCategory category);
        public void Delete(ProductCategory category);
        public Task<bool> IsExistsById(int id);
        public Task<bool> IsTitleDuplicate(string title);
    }
}
