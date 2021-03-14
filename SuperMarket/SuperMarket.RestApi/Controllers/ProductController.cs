using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.Products.Contracts;

namespace SuperMarket.RestApi.Controllers
{
    [ApiController,Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ProductServices _services;

        public ProductController(ProductServices services)
        {
            _services = services;
        }

        [HttpPost]
        public void Add(AddProductDto dto)
        {
            _services.Add(dto);
        }

        [HttpGet]
        public IList<GetAllProductDto> GetAll()
        {
            return _services.GetAll();
        }

        [HttpGet("{id}")]
        public GetByIdProductDto GetById(int id)
        {
            return _services.GetById(id);
        }

        [HttpPut("{id}")]
        public void Update(int id,UpdateProductDto dto)
        {
            _services.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _services.Delete(id);
        }
    }
}