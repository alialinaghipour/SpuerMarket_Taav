using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.ProductCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public ProductCategory FindById(int id)
        {
            return _set.Find(id);
        }

        public IList<GetAllProductCategoryDto> GetAll()
        {
            return _set.Select(_ => new GetAllProductCategoryDto()
            {
                Id = _.Id,
                Tilte = _.Tilte
            }).ToList();
        }

        public FindByIdProductCategoryDto GetById(int id)
        {
            return _set.Select(_ => new FindByIdProductCategoryDto()
            {
                Id = _.Id,
                Tilte = _.Tilte
            }).SingleOrDefault();
        }

        public bool IsExistsById(int id)
        {
            return _context.ProductCategories.Any(_ => _.Id == id);
        }

        public bool IsTitleDuplicate(string title)
        {
            return _context.ProductCategories.Any(_ => _.Tilte == title);
        }
    }
}
