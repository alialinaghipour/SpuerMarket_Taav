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

        public void Delete(SalesFactor factor)
        {
            _set.Remove(factor);
        }

        public async Task<SalesFactor> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<GetAllSalesFactoryDto>> GetAll()
        {
            //var good = _context.Products.ToList();
            var query = (from saleFactor in _set
                         join product in _context.Products on saleFactor.ProductCode equals product.Code
                         select new GetAllSalesFactoryDto
                         {
                             Id = saleFactor.Id,
                             Count = saleFactor.Count,
                             SalesDate = saleFactor.SalesDate,
                             ProductCode = saleFactor.ProductCode,
                             TotalPrice = product.Price*saleFactor.Count
                         }).ToListAsync();

            return await query;

            //return await _set.Select(_ => new GetAllSalesFactoryDto()
            //{
            //    Id = _.Id,
            //    Count = _.Count,
            //    SalesDate = _.SalesDate,
            //    ProductCode = _.ProductCode,
            //   // TotalPrice = _.pro
                
            //}).ToListAsync();
        }

        public async Task<GetByIdSalesFactoryDto> GetById(int id)
        {

            var query = (from saleFactor in _set
                         join product in _context.Products on saleFactor.ProductCode equals product.Code
                         where saleFactor.Id == id
                         select new GetByIdSalesFactoryDto
                         {
                             Id = saleFactor.Id,
                             Count = saleFactor.Count,
                             SalesDate = saleFactor.SalesDate,
                             ProductCode = saleFactor.ProductCode,
                             TotalPrice = product.Price * saleFactor.Count
                         }).SingleOrDefaultAsync();

            return await query;

            //return await _set.Select(_ => new GetByIdSalesFactoryDto()
            //{
            //    Id = _.Id,
            //    Count = _.Count,
            //    SalesDate = _.SalesDate,
            //    ProductCode = _.ProductCode
            //}).SingleOrDefaultAsync();
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _set.AnyAsync(_ => _.Id == id);
        }
    }
}
