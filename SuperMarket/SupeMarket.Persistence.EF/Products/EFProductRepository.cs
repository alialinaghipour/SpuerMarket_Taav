using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupeMarket.Persistence.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<Product> _set;

        public EFProductRepository(EFDataContext context, DbSet<Product> set)
        {

            _context = context;
            _set = _context.Products;
        }

        public void Add(Product product)
        {
            _set.Add(product);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product FindByProductCode(string code)
        {
            throw new NotImplementedException();
        }

        public IList<GetAllProductDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public GetByIdProductDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsCodeDuplicate(string code)
        {
            throw new NotImplementedException();
        }

        public bool IsExistsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
