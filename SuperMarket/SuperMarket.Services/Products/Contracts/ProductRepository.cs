using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.Products.Contracts
{
    public interface ProductRepository
    {
        public IList<GetAllProductDto> GetAll();
        public GetByIdProductDto GetById(int id);
        public Product FindById(int id);
        public void Add(Product product);
        public void Delete(Product product);
        public Product FindByProductCode(string code);
        public bool IsCodeDuplicate(string code);
        public bool IsExistsById(int id);
    }
}
