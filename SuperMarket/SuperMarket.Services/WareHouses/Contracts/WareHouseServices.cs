using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.WareHouses
{
    public interface WareHouseServices
    {
        Task<int> Add(AddWareHouseDto dto);
        Task Delete(int id);
        Task Update(int id, UpdateWareHouseDto dto);
        Task<IList<GetAllWareHouseDto>> GetAll();
        Task<GetByIdWareHouse> GetById(int id);
    }
}
