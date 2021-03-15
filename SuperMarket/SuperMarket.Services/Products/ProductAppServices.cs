﻿using SuperMarket.Entities;
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

        public async Task<int> Add(AddProductDto dto)
        {
            await CheckedCodeDuplicate(dto.Code);

            await CheckedProductCategoryExistsById(dto.CategoryId);

            Product product = new Product()
            {
                Code = dto.Code,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Count = dto.Count,
                Price = dto.Price,
                WareHouseId=dto.WareHouseId
            };

            _repository.Add(product);

            _unitOfWork.Complete();

            return product.Id;
        }

        private async Task CheckedCodeDuplicate(string code)
        {
            if (await _repository.IsCodeDuplicate(code))
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

        public async Task Update(int id, UpdateProductDto dto)
        {
           await CheckedCodeDuplicate(dto.Code);

           await CheckedProductCategoryExistsById(dto.CategoryId);

            var product = await _repository.FindById(id);

            CheckedExistsProduct(product);

            product.Code = dto.Code;
            product.CategoryId = dto.CategoryId;
            product.Count = dto.Count;
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.WareHouseId = dto.WareHouseId;

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

        public async Task Delete(int id)
        {
            var product =await _repository.FindById(id);

            CheckedExistsProduct(product);

            _repository.Delete(product);

            _unitOfWork.Complete();
        }
        private async Task CheckedProductExistsById(int id)
        {
            if (!await _repository.IsExistsById(id))
            {
                //بعدا مینویسم
                throw new Exception();
            }
        }

        public async Task<GetByIdProductDto> GetById(int id)
        {
            await CheckedProductExistsById(id);
            return await _repository.GetById(id);
        }
        public async Task<IList<GetAllProductDto>> GetAll()
        {
            return await _repository.GetAll();
        }


    }
}
