
using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.ProductCategories
{
    public class ProductCategoryAppServices : ProductCategoryServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductCagetoryRepository _repository;

        public ProductCategoryAppServices(UnitOfWork unitOfWork, ProductCagetoryRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(AddProductCategoryDto dto)
        {
            if (_repository.IsTitleDuplicate(dto.Tilte))
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }

            ProductCategory category = new ProductCategory()
            {
                Tilte = dto.Tilte
            };

            _repository.Add(category);

            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            if (!_repository.IsExistsById(id))
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }

            _repository.Delete(id);

            _unitOfWork.Complete();
        }

        public FindByIdProductCategoryDto FindById(int id)
        {
            if (!_repository.IsExistsById(id))
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }

           return _repository.FindById(id);
        }

        public IEnumerable<GetAllProductCategoryDto> GetAll()
        {
           return _repository.GetAll();
        }

        public void Update(int id,UpdateProductCategoryDto dto)
        {
            var category = _repository.FindById(id);

            if (category != null)
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }

            if (_repository.IsTitleDuplicate(dto.Tilte))
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }

            category.Tilte = dto.Tilte;

            _unitOfWork.Complete();
        }
    }
}
