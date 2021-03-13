using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Infrastructure.Application
{
    public interface UnitOfWork
    {
        void Complete();
    }
}
