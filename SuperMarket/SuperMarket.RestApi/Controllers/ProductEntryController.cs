using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.ProductEntries.Contracts;

namespace SuperMarket.RestApi.Controllers
{
    [ApiController,Route("api/product-entries")]
    public class ProductEntryController : Controller
    {
        private readonly ProductEntryServices _services;

        public ProductEntryController(ProductEntryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddProductEntryDto dto)
        {
           return await _services.Add(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllProductEntryDto>> GetAll()
        {
            return await _services.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<GetByIdProductEntryDto> GetById(int id)
        {
            return await _services.GetById(id);
        }
    }
}