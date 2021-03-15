using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.SalesFactories
{
    public interface SalesFactoryServices
    {
        public Task<IList<GetAllSalesFactoryDto>> GetAll();
        public Task<int> Add(AddSalesFactorDto dto);
        public Task Delete(int id);
        public Task<GetByIdSalesFactoryDto> GetById(int id);
    }
}
