using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.WareHouses;

namespace SuperMarket.RestApi.Controllers
{
    [ApiController,Route("api/warehouses")]
    public class WareHousesController : Controller
    {
        private readonly WareHouseServices _services;

        public WareHousesController(WareHouseServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddWareHouseDto dto)
        {
          return  await _services.Add(dto);
        }

        [HttpPut("{id}")]
        public async Task Update(int id,UpdateWareHouseDto dto)
        {
            await _services.Update(id, dto);
        }

        [HttpGet]
        public async Task<IList<GetAllWareHouseDto>> GetAll()
        {
            return await _services.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<GetByIdWareHouse> GetById(int id)
        {
            return await _services.GetById(id);
        }
    }
}