using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.SalesFactories
{
    public interface SalesFactoryServices
    {
        public IList<GetAllSalesFactoryDto> GetAll();
        public void Add(AddSalesFactorDto dto);
        public GetByIdSalesFactoryDto GetById(int id);
    }
}
