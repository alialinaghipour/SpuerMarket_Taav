using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductEntries.Contracts
{
    public interface ProductEntryRepository
    {
        public IList<GetAllProductEntryDto> GetAll();
        public ProductEntry FindById(int id);
        public void Add(ProductEntry product);
        public void Delete(ProductEntry product);
        public GetByIdProductEntryDto GetById(int id);
        public bool IsExistsById(int id);
    }
}
