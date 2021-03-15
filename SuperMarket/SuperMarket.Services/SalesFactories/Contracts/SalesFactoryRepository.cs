using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.SalesFactories
{
    public interface SalesFactoryRepository
    {
        public Task<IList<GetAllSalesFactoryDto>> GetAll();
        public Task<SalesFactor> FindById(int id);
        public void Add(SalesFactor factor);
        public void Delete(SalesFactor factor);
        public Task<GetByIdSalesFactoryDto> GetById(int id);
        public Task<bool> IsExistsById(int id);
    }
}
