using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.Products.Contracts
{
    public interface ProductRepository
    {
        public Task<IList<GetAllProductDto>> GetAll();
        public Task<GetByIdProductDto> GetById(int id);
        public Task<Product> FindById(int id);
        public void Add(Product product);
        public void Delete(Product product);
        public Task<Product> FindByProductCode(string code);
        public Task<bool> IsCodeDuplicate(string code);
        public Task<bool> IsExistsById(int id);
    }
}
