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
        public async Task<int> Add(AddProductDto dto)
        {
          return  await _services.Add(dto);
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
        public async Task Update(int id,UpdateProductDto dto)
        {
           await _services.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _services.Delete(id);
        }
    }
}