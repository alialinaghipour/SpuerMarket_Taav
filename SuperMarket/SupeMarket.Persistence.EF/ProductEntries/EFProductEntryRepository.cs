using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.ProductEntries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public ProductEntry FindById(int id)
        {
            return _set.Find(id);
        }

        public IList<GetAllProductEntryDto> GetAll()
        {
            return _set.Select(_ => new GetAllProductEntryDto()
            {
                Id = _.Id,
                Count = _.Count,
                EntryDate = _.EntryDate,
                ProdcutCode = _.ProdcutCode
            }).ToList();
        }

        public GetByIdProductEntryDto GetById(int id)
        {
            return _set.Select(_ => new GetByIdProductEntryDto()
            {
                Id = _.Id,
                Count = _.Count,
                EntryDate = _.EntryDate,
                ProdcutCode = _.ProdcutCode
            }).SingleOrDefault();
        }

        public bool IsExistsById(int id)
        {
            return _set.Any(_ => _.Id == id);
        }
    }
}
