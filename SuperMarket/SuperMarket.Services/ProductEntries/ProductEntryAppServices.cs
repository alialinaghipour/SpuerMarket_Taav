﻿using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.ProductEntries.Contracts;
using SuperMarket.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<int> Add(AddProductEntryDto dto)
        {

            var product = await _productRepository.FindByProductCode(dto.ProdcutCode);

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

            return entry.Id;
        }

        private void CheckedExistsProduct(Product product)
        {
            if (product == null)
            {
                //**********
                throw new Exception();
            }
        }

        public async Task<IList<GetAllProductEntryDto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<GetByIdProductEntryDto> GetById(int id)
        {
            await CheckedExistsProductEntry(id);
            return await _repository.GetById(id);
        }

        private async Task CheckedExistsProductEntry(int id)
        {
            if (!await _repository.IsExistsById(id))
            {
                //************
                throw new Exception();
            }
        }

        public async Task Delete(int id)
        {
            var productEntry = await _repository.FindById(id);

            if (productEntry == null)
            {
                //********
                throw new Exception();
            }

            var product = await _productRepository.FindByProductCode(productEntry.ProdcutCode);

            if(product.Count< productEntry.Count)
            {
                //**********
                throw new Exception();
            }

            product.Count -= productEntry.Count;

            _repository.Delete(productEntry);

            _unitOfWork.Complete();
        }
    }
}
