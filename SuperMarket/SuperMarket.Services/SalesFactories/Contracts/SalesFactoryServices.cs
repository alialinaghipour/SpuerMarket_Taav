using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.SalesFactories
{
    public interface SalesFactoryServices
    {
        public Task<IList<GetAllSalesFactoryDto>> GetAll();
        public Task Add(AddSalesFactorDto dto);
        public Task<GetByIdSalesFactoryDto> GetById(int id);
    }
}
