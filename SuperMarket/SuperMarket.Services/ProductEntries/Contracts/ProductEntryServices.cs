using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductEntries.Contracts
{
    public interface ProductEntryServices
    {
        public IList<GetAllProductEntryDto> GetAll();
        public void Add(AddProductEntryDto dto);
        public void Update(UpdateProductEntryDto dto);
        public void Delete(int id);
        public GetByIdProductEntryDto GetById(int id);
    }
}
