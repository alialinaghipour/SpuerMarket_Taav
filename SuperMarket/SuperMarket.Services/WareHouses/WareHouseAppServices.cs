using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Services.WareHouses
{
    public class WareHouseAppServices : WareHouseServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly WareHouseRepository _repository;

        public WareHouseAppServices(UnitOfWork unitOfWork,WareHouseRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<int> Add(AddWareHouseDto dto)
        {
            WareHouse wareHouse = new WareHouse()
            {
                Count = dto.Count,
                Name = dto.Name,
            };

            _repository.Add(wareHouse);

            _unitOfWork.Complete();

            return wareHouse.Id;
        }

        public async Task Delete(int id)
        {
            var wareHouse = await _repository.FindById(id);

            CheckedExistsWarehouse(wareHouse);

            _repository.Delete(wareHouse);

            _unitOfWork.Complete();
        }

        private 
            void CheckedExistsWarehouse(WareHouse wareHouse)
        {
            if (wareHouse == null)
            {
                throw new Exception();
            }
        }

        public async Task<IList<GetAllWareHouseDto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<GetByIdWareHouse> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(int id, UpdateWareHouseDto dto)
        {
            var wareHouse = await _repository.FindById(id);

            CheckedExistsWarehouse(wareHouse);

            wareHouse.Count = dto.Count;
            wareHouse.Name = dto.Name;

            _unitOfWork.Complete();
        }
    }
}
