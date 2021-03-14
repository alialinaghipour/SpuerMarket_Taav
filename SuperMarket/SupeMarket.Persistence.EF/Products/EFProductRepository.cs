using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Product FindById(int id)
        {
            return _set.Find(id);
        }

        public Product FindByProductCode(string code)
        {
            return _set.SingleOrDefault(_ => _.Code == code);
        }

        public IList<GetAllProductDto> GetAll()
        {
            return _set.Select(_ => new GetAllProductDto()
            {
                Code = _.Code,
                Count = _.Count,
                Name = _.Name,
                Price = _.Price
            }).ToList();
        }

        public GetByIdProductDto GetById(int id)
        {
            return _set.Select(_ => new GetByIdProductDto()
            {
                Code = _.Code,
                Count = _.Count,
                Name = _.Name,
                Price = _.Price
            }).SingleOrDefault();
        }

        public bool IsCodeDuplicate(string code)
        {
            return _set.Any(_ => _.Code == code);
        }

        public bool IsExistsById(int id)
        {
            return _set.Any(_ => _.Id == id);

        }
    }
}
