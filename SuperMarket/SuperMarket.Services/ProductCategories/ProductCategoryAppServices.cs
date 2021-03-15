
using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<int> Add(AddProductCategoryDto dto)
        {

           await CheckedTitleDeuplicate(dto.Tilte);

            ProductCategory category = new ProductCategory()
            {
                Tilte = dto.Tilte
            };

            _repository.Add(category);

            _unitOfWork.Complete();

            return category.Id;
        }

        private async Task CheckedTitleDeuplicate(string title)
        {
            if (await _repository.IsTitleDuplicate(title))
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }
        }

        public async Task Update(int id,UpdateProductCategoryDto dto)
        {
            var category =await  _repository.FindById(id);

            CheckedProductCategoryExists(category);

            await CheckedTitleDeuplicate(dto.Tilte);

             category.Tilte = dto.Tilte;

            _unitOfWork.Complete();
        }

        private void CheckedProductCategoryExists(ProductCategory category)
        {
            if (category == null)
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }
        }

        public async Task Delete(int id)
        {
            var category =await _repository.FindById(id);

            CheckedProductCategoryExists(category);

            _repository.Delete(category);

            _unitOfWork.Complete();
        }

        private async Task CheckedExisteById(int id)
        {
            if (!await _repository.IsExistsById(id))
            {
                //خطا میسازم ، که فعلا حال ندارم
                throw new Exception();
            }
        }

        public async Task<FindByIdProductCategoryDto> FindById(int id)
        {
           await CheckedExisteById(id);

           return await _repository.GetById(id);
        }

        public async Task<IList<GetAllProductCategoryDto>> GetAll()
        {
           return await _repository.GetAll();
        }

    }
}
