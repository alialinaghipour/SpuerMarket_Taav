using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.ProductEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupeMarket.Persistence.EF.ProductEntries
{
    public class EFProductEntryRepository : ProductEntryRepository
    {

        private readonly EFDataContext _context;
        private readonly DbSet<ProductEntry> _set;

        public EFProductEntryRepository(EFDataContext context)
        {

            _context = context;
            _set = _context.ProductEntries;
        }

        public void Add(ProductEntry product)
        {
            _set.Add(product);
        }

        public async Task<ProductEntry> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<GetAllProductEntryDto>> GetAll()
        {
            return await _set.Select(_ => new GetAllProductEntryDto()
            {
                Id = _.Id,
                Count = _.Count,
                EntryDate = _.EntryDate,
                ProdcutCode = _.ProdcutCode
            }).ToListAsync();
        }

        public async Task<GetByIdProductEntryDto> GetById(int id)
        {
            return await _set.Select(_ => new GetByIdProductEntryDto()
            {
                Id = _.Id,
                Count = _.Count,
                EntryDate = _.EntryDate,
                ProdcutCode = _.ProdcutCode
            }).SingleOrDefaultAsync();
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _set.AnyAsync(_ => _.Id == id);
        }
    }
}
