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
        public void Add(AddProductCategoryDto dto)
        {
            _services.Add(dto);
        }

        [HttpGet]
        public IList<GetAllProductCategoryDto> GetAll()
        {
            return _services.GetAll();
        }

        [HttpGet("{id}")]
        public FindByIdProductCategoryDto GetById(int id)
        {
            return _services.FindById(id);
        }

        [HttpPut("{id}")]
        public void Update(int id,UpdateProductCategoryDto dto)
        {
            _services.Update(id,dto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _services.Delete(id);
        }
    }
}