using Microsoft.EntityFrameworkCore;
using SupeMarket.Persistence.EF;
using SuperMarket.Entities;
using SuperMarket.Services.WareHouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.EF.WareHouses
{
    public class EFWareHouseRepository : WareHouseRepository
    {
        private readonly EFDataContext _context;

        public EFWareHouseRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(WareHouse wareHouse)
        {
            _context.WareHouses.Add(wareHouse);
        }

        public void Delete(WareHouse wareHouse)
        {
            _context.WareHouses.Remove(wareHouse);
        }

        public async Task<WareHouse> FindById(int id)
        {
            return await _context.WareHouses.FindAsync(id);
        }

        public async Task<IList<GetAllWareHouseDto>> GetAll()
        {
            return await _context.WareHouses.Select(_ => new GetAllWareHouseDto()
            {
                Count = _.Count,
                Id = _.Id,
                Name = _.Name
            }).ToListAsync();
        }

        public async Task<GetByIdWareHouse> GetById(int id)
        {
            return await _context.WareHouses.Select(_ => new GetByIdWareHouse()
            {
                Count = _.Count,
                Id = _.Id,
                Name = _.Name
            }).SingleOrDefaultAsync();
        }

        public async Task<bool> IsExisteById(int id)
        {
            return await _context.WareHouses.AnyAsync(_=>_.Id==id);
        }
    }
}
