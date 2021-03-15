﻿using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<int> Add(AddSalesFactorDto dto)
        {

            var product =await _productRepository.FindByProductCode(dto.ProductCode);

            CheckedExistsProduct(product);

            CheckedProductCountMoreFormFactorCount(product.Count, dto.Count);

            product.Count -= dto.Count;

            SalesFactor factor = new SalesFactor()
            {
                Count = dto.Count,
                ProductCode = dto.ProductCode,
                SalesDate = DateTime.Now
            };

            _repository.Add(factor);

            _unitOfWork.Complete();

            return factor.Id;
        }

        private void CheckedProductCountMoreFormFactorCount(int productCount,int factorCount)
        {
            if (productCount < factorCount)
            {
                throw new Exception();
            }
        }

        private void CheckedExistsProduct(Product product)
        {
            if (product == null)
            {
                //**********
                throw new Exception();
            }
        }


        public async Task<IList<GetAllSalesFactoryDto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<GetByIdSalesFactoryDto> GetById(int id)
        {
            await CheckedExistsById(id);
            return await _repository.GetById(id);
        }

        private async Task CheckedExistsById(int id)
        {
            if (! await _repository.IsExistsById(id))
            {
                //*********
                throw new Exception();
            }
        }

        public async Task Delete(int id)
        {
            var factor = await _repository.FindById(id);

            if (factor == null)
            {
                //*****
                throw new Exception();
            }

            var product = await _productRepository.FindByProductCode(factor.ProductCode);

            product.Count += factor.Count;

            _repository.Delete(factor);

            _unitOfWork.Complete();
        }
    }
}
