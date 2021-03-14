using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.SalesFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public SalesFactor FindById(int id)
        {
            return _set.Find(id);
        }

        public IList<GetAllSalesFactoryDto> GetAll()
        {
            return _set.Select(_ => new GetAllSalesFactoryDto()
            {
                Id = _.Id,
                Count = _.Count,
                SalesDate = _.SalesDate,
                ProductCode = _.ProductCode
            }).ToList();
        }

        public GetByIdSalesFactoryDto GetById(int id)
        {
            return _set.Select(_ => new GetByIdSalesFactoryDto()
            {
                Id = _.Id,
                Count = _.Count,
                SalesDate = _.SalesDate,
                ProductCode = _.ProductCode
            }).SingleOrDefault();
        }

        public bool IsExistsById(int id)
        {
            return _set.Any(_ => _.Id == id);
        }
    }
}
