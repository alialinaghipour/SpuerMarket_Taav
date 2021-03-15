using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupeMarket.Persistence.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<Product> _set;

        public EFProductRepository(EFDataContext context)
        {

            _context = context;
            _set = _context.Products;
        }

        public void Add(Product product)
        {
            _set.Add(product);
        }

        public void Delete(Product product)
        {
            _set.Remove(product);
        }

        public async Task<Product> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<Product> FindByProductCode(string code)
        {
            return await _set.SingleOrDefaultAsync(_ => _.Code == code);
        }

        public async Task<IList<GetAllProductDto>> GetAll()
        {
            return await _set.Select(_ => new GetAllProductDto()
            {
                Id=_.Id,
                Code = _.Code,
                Count = _.Count,
                Name = _.Name,
                Price = _.Price,
                WareHouseId=_.WareHouseId,
                CategoryId = _.CategoryId,
                MinimumInventory=_.MinimumInventory
            }).ToListAsync();
        }

        public async Task<GetByIdProductDto> GetById(int id)
        {
            return await _set.Select(_ => new GetByIdProductDto()
            {
                Id = _.Id,
                Code = _.Code,
                Count = _.Count,
                Name = _.Name,
                Price = _.Price,
                WareHouseId = _.WareHouseId,
                CategoryId=_.CategoryId,
                MinimumInventory=_.MinimumInventory,
            }).SingleAsync();
        }

        public async Task<bool> IsCodeDuplicate(string code)
        {
            return await _set.AnyAsync(_ => _.Code == code);
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _set.AnyAsync(_ => _.Id == id);

        }
    }
}
