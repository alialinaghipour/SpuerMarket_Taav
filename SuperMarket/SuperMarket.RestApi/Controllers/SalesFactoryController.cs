using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.SalesFactories;

namespace SuperMarket.RestApi.Controllers
{
    [ApiController,Route("api/sales-factory")]
    public class SalesFactoryController : Controller
    {
        private readonly SalesFactoryServices _services;

        public SalesFactoryController(SalesFactoryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public void Add(AddSalesFactorDto dto)
        {
            _services.Add(dto);
        }

        [HttpGet]
        public IList<GetAllSalesFactoryDto> GetAll()
        {
            return _services.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdSalesFactoryDto GetById(int id)
        {
            return _services.GetById(id);
        }
    }
}