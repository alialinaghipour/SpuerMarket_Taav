using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.Products.Contracts
{
    public interface ProductServices
    {
        public IEnumerable<GetAllProductDto> GetAll();
        public GetByIdProductDto GetById(int id);
        public void Add(AddProductDto dto);
        public void Update(int id,UpdateProductDto dto);
        public void Delete(int id);
    }
}
