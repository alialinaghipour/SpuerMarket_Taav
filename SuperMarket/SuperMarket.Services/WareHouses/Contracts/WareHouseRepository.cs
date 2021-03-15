using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.WareHouses
{
    public interface WareHouseRepository
    {
        void Add(WareHouse wareHouse);
        void Delete(WareHouse wareHouse);
        Task<IList<GetAllWareHouseDto>> GetAll();
        Task<GetByIdWareHouse> GetById(int id);
        Task<WareHouse> FindById(int id);
        Task<bool> IsExisteById(int id);
    }
}
