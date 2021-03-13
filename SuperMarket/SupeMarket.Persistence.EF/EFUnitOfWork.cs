using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupeMarket.Persistence.EF
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly EFDataContext _context;

        public EFUnitOfWork(EFDataContext context)
        {
            _context = context;
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
