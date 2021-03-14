using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.ProductCategories.Contracts;
using SuperMarket.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.Products
{
    public class ProductAppServices : ProductServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _repository;
        private readonly ProductCagetoryRepository _cagetoryRepository;

        public ProductAppServices(UnitOfWork unitOfWork,ProductRepository repository,ProductCagetoryRepository cagetoryRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _cagetoryRepository = cagetoryRepository;
        }

        public void Add(AddProductDto dto)
        {
            CheckedCodeDuplicate(dto.Code);

            CheckedProductCategoryExistsById(dto.CategoryId);

            Product product = new Product()
            {
                Code = dto.Code,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Count = dto.Count,
                Price = dto.Price
            };

            _repository.Add(product);

            _unitOfWork.Complete();
        }

        private void CheckedCodeDuplicate(string code)
        {
            if (_repository.IsCodeDuplicate(code))
            {
                //بعدا مینویسم
                throw new Exception();
            }
        }

        private async Task CheckedProductCategoryExistsById(int categoryId)
        {
            if (!await _cagetoryRepository.IsExistsById(categoryId))
            {
                //بعدا مینویسم
                throw new Exception();
            }
        }

        public void Update(int id, UpdateProductDto dto)
        {
            CheckedCodeDuplicate(dto.Code);

            CheckedProductCategoryExistsById(dto.CategoryId);

            var product = _repository.FindById(id);

            CheckedExistsProduct(product);

            product.Code = dto.Code;
            product.CategoryId = dto.CategoryId;
            product.Count = dto.Count;
            product.Name = dto.Name;
            product.Price = dto.Price;

            _unitOfWork.Complete();
        }

        private void CheckedExistsProduct(Product product)
        {
            if (product == null)
            {
                //**********
                throw new Exception();
            }
        }

        public void Delete(int id)
        {
            var product = _repository.FindById(id);

            CheckedExistsProduct(product);

            _repository.Delete(product  );

            _unitOfWork.Complete();
        }
        private void CheckedProductExistsById(int id)
        {
            if (!_repository.IsExistsById(id))
            {
                //بعدا مینویسم
                throw new Exception();
            }
        }

        public GetByIdProductDto GetById(int id)
        {
            CheckedProductExistsById(id);
            return _repository.GetById(id);
        }
        public IList<GetAllProductDto> GetAll()
        {
            return _repository.GetAll();
        }


    }
}
