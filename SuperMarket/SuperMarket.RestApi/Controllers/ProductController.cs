using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.Products.Contracts;

namespace SuperMarket.RestApi.Controllers
{
    [ApiController,Route("api/products")]
    public class ProductController : Controller
    {
        private readonly ProductServices _services;

        public ProductController(ProductServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task Add(AddProductDto dto)
        {
            await _services.Add(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllProductDto>> GetAll()
        {
            return await _services.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<GetByIdProductDto> GetById(int id)
        {
            return await _services.GetById(id);
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