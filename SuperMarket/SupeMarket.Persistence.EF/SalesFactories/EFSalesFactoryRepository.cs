using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.SalesFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupeMarket.Persistence.EF.SalesFactories
{
    public class EFSalesFactoryRepository : SalesFactoryRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<SalesFactor> _set;

        public EFSalesFactoryRepository(EFDataContext context)
        {

            _context = context;
            _set = _context.SalesFactors;
        }

        public void Add(SalesFactor factor)
        {
            _set.Add(factor);
        }

        public async Task<SalesFactor> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<GetAllSalesFactoryDto>> GetAll()
        {
            return await _set.Select(_ => new GetAllSalesFactoryDto()
            {
                Id = _.Id,
                Count = _.Count,
                SalesDate = _.SalesDate,
                ProductCode = _.ProductCode
            }).ToListAsync();
        }

        public async Task<GetByIdSalesFactoryDto> GetById(int id)
        {
            return await _set.Select(_ => new GetByIdSalesFactoryDto()
            {
                Id = _.Id,
                Count = _.Count,
                SalesDate = _.SalesDate,
                ProductCode = _.ProductCode
            }).SingleOrDefaultAsync();
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _set.AnyAsync(_ => _.Id == id);
        }
    }
}
