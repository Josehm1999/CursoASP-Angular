using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface ISupplierRepository: IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPagedList(int page, int rows);
    }
}
