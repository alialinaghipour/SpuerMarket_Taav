using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.ProductEntries.Contracts
{
    public interface ProductEntryServices
    {
        public Task<IList<GetAllProductEntryDto>> GetAll();
        public Task<int> Add(AddProductEntryDto dto);
        public Task Delete(int id);
        public Task<GetByIdProductEntryDto> GetById(int id);
    }
}
