﻿using Models;
using System.Collections.Generic;

namespace SystemsBusinnessLogic.Interfaces
{
    public interface ISupplierLogic
    {

        Supplier GetById(int id);
        IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm);
        int Insert(Supplier supplier);
        bool Update(Supplier supplier);
        bool Delete(Supplier supplier);

    }
}
