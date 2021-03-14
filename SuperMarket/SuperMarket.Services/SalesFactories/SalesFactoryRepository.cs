using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.SalesFactories
{
    public interface SalesFactoryRepository
    {
        public IList<GetAllSalesFactoryDto> GetAll();
        public SalesFactor FindById(int id);
        public void Add(SalesFactor factor);
        public GetByIdSalesFactoryDto GetById(int id);
        public bool IsExistsById(int id);
    }
}
