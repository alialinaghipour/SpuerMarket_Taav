using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.ProductEntries.Contracts;
using SuperMarket.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductEntries
{
    public class ProductEntryAppServices : ProductEntryServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductEntryRepository _repository;
        private readonly ProductRepository _productRepository;

        public ProductEntryAppServices(UnitOfWork unitOfWork,ProductEntryRepository repository,ProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _productRepository = productRepository;
        }

        public void Add(AddProductEntryDto dto)
        {

            CheckedCountMoreZero(dto.Count);

            var product = _productRepository.FindByProductCode(dto.ProdcutCode);

            CheckedExistsProduct(product);

            product.Count += dto.Count;

            ProductEntry entry = new ProductEntry()
            {
                Count = dto.Count,
                EntryDate = DateTime.Now,
                ProdcutCode = dto.ProdcutCode
            };

            _repository.Add(entry);

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

        private void CheckedCountMoreZero(int count)
        {
            const int oneNumber = 1;
            if (count < oneNumber)
            {
                //**********
                throw new Exception();
            }
        }

        public IList<GetAllProductEntryDto> GetAll()
        {
            return _repository.GetAll();
        }

        public GetByIdProductEntryDto GetById(int id)
        {
            CheckedExistsProductEntry(id);
            return _repository.GetById(id);
        }

        private void CheckedExistsProductEntry(int id)
        {
            if (!_repository.IsExistsById(id))
            {
                //************
                throw new Exception();
            }
        }
    }
}
