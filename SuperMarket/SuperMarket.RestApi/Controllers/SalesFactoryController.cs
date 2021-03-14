using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.SalesFactories;

namespace SuperMarket.RestApi.Controllers
{
    [ApiController,Route("api/sales-factories")]
    public class SalesFactoryController : Controller
    {
        private readonly SalesFactoryServices _services;

        public SalesFactoryController(SalesFactoryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task Add(AddSalesFactorDto dto)
        {
            await _services.Add(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllSalesFactoryDto>> GetAll()
        {
            return await _services.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<GetByIdSalesFactoryDto> GetById(int id)
        {
            return await _services.GetById(id);
        }
    }
}