using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupeMarket.Persistence.EF.ProductCategories
{
    public class EFProductCategoryRepository : ProductCagetoryRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductCategory> _set;

        public EFProductCategoryRepository(EFDataContext context)
        {
           
            _context = context;
            _set = _context.ProductCategories;
        }

        public void Add(ProductCategory category)
        {
            _set.Add(category);
        }

        public void Delete(ProductCategory category)
        {
            _set.Remove(category);
        }

        public async Task<ProductCategory> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<GetAllProductCategoryDto>> GetAll()
        {
            return await _set.Select(_ => new GetAllProductCategoryDto()
            {
                Id = _.Id,
                Tilte = _.Tilte
            }).ToListAsync();
        }

        public async Task<FindByIdProductCategoryDto> GetById(int id)
        {
            return await _set.Select(_ => new FindByIdProductCategoryDto()
            {
                Id = _.Id,
                Tilte = _.Tilte
            }).SingleOrDefaultAsync();
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _context.ProductCategories.AnyAsync(_ => _.Id == id);
        }

        public async Task<bool> IsTitleDuplicate(string title)
        {
            return await _context.ProductCategories.AnyAsync(_ => _.Tilte == title);
        }
    }
}
