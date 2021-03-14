using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.ProductEntries.Contracts
{
    public interface ProductEntryRepository
    {
        public Task<IList<GetAllProductEntryDto>> GetAll();
        public Task<ProductEntry> FindById(int id);
        public void Add(ProductEntry product);
        public Task<GetByIdProductEntryDto> GetById(int id);
        public Task<bool> IsExistsById(int id);
    }
}
