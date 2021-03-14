using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.SalesFactories
{
    public class SalesFactoryAppServices : SalesFactoryServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly SalesFactoryRepository _repository;
        private readonly ProductRepository _productRepository;

        public SalesFactoryAppServices(UnitOfWork unitOfWork,SalesFactoryRepository repository,ProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _productRepository = productRepository;
        }
        public void Add(AddSalesFactorDto dto)
        {
            CheckedInformation(dto.IsInformation);

            CheckedCountMoreZero(dto.Count);

            var product = _productRepository.FindByProductCode(dto.ProductCode);

            CheckedExistsProduct(product);

            product.Count -= dto.Count;

            SalesFactor factor = new SalesFactor()
            {
                Count = dto.Count,
                ProductCode = dto.ProductCode,
                SalesDate = DateTime.Now
            };

            _repository.Add(factor);

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

        private void CheckedInformation(bool info)
        {
            if (!info)
            {
                //**********
                throw new Exception();
            }
        }

        public IList<GetAllSalesFactoryDto> GetAll()
        {
            return _repository.GetAll();
        }

        public GetByIdSalesFactoryDto GetById(int id)
        {
            CheckedExistsById(id);
            return _repository.GetById(id);
        }

        private void CheckedExistsById(int id)
        {
            if (!_repository.IsExistsById(id))
            {
                //*********
                throw new Exception();
            }
        }
    }
}
