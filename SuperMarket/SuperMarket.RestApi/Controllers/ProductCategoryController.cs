using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Services.ProductCategories.Contracts;

namespace SuperMarket.RestApi.Controllers
{
    [ApiController,Route("api/product-categories")]
    public class ProductCategoryController : Controller
    {
        private readonly ProductCategoryServices _services;

        public ProductCategoryController(ProductCategoryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<int> Add(AddProductCategoryDto dto)
        {
          return  await _services.Add(dto);
        }

        [HttpGet]
        public async Task<IList<GetAllProductCategoryDto>> GetAll()
        {
            return await _services.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<FindByIdProductCategoryDto> GetById(int id)
        {
            return await _services.FindById(id);
        }

        [HttpPut("{id}")]
        public async Task Update(int id,UpdateProductCategoryDto dto)
        {
           await _services.Update(id,dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _services.Delete(id);
        }
    }
}