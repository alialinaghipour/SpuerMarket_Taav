
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

            CheckedTitleDeuplicate(dto.Tilte);

            ProductCategory category = new ProductCategory()
            {
                Tilte = dto.Tilte
            };

            _repository.Add(category);

            _unitOfWork.Complete();
        }

        private void CheckedTitleDeuplicate(string title)
        {
            if (_repository.IsTitleDuplicate(title))
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }
        }

        public void Update(int id,UpdateProductCategoryDto dto)
        {
            var category = _repository.FindById(id);

            CheckedProductCategoryExists(category);

            CheckedTitleDeuplicate(dto.Tilte);

            category.Tilte = dto.Tilte;

            _unitOfWork.Complete();
        }

        private  void CheckedProductCategoryExists(ProductCategory category)
        {
            if (category == null)
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }
        }

        public void Delete(int id)
        {
            var category = _repository.FindById(id);

            CheckedProductCategoryExists(category);

            _repository.Delete(category);

            _unitOfWork.Complete();
        }

        private void CheckedExisteById(int id)
        {
            if (!_repository.IsExistsById(id))
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }
        }

        public FindByIdProductCategoryDto FindById(int id)
        {
            CheckedExisteById(id);

           return _repository.GetById(id);
        }

        public IList<GetAllProductCategoryDto> GetAll()
        {
           return _repository.GetAll();
        }

    }
}
