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
        public void Add(AddProductEntryDto dto)
        {
            _services.Add(dto);
        }

        [HttpGet]
        public IList<GetAllProductEntryDto> GetAll()
        {
            return _services.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdProductEntryDto GetById(int id)
        {
            return _services.GetById(id);
        }
    }
}