using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.ProductCategories.Contracts
{
    public interface ProductCategoryServices
    {
        public Task<IList<GetAllProductCategoryDto>> GetAll();
        public Task<FindByIdProductCategoryDto> FindById(int id);
        public Task<int> Add(AddProductCategoryDto dto);
        public Task Update(int id, UpdateProductCategoryDto dto);
        public Task Delete(int id);
    }
}
