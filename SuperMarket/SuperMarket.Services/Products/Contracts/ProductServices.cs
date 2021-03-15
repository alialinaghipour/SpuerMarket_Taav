using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.Products.Contracts
{
    public interface ProductServices
    {
        public Task<IList<GetAllProductDto>> GetAll();
        public Task<GetByIdProductDto> GetById(int id);
        public Task<int> Add(AddProductDto dto);
        public Task Update(int id,UpdateProductDto dto);
        public Task Delete(int id);
    }
}
