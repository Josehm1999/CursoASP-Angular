using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnitOfWork;

namespace DataAccess
{
    public class DAUnitOfWork : IUnitOfWork
    {
        public DAUnitOfWork(string connectionString) { 
        Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
        Supplier = new SupplierRepository(connectionString);
        }
        public ICustomerRepository Customer { get ; private set; }

        public IUserRepository User { get; private set; }

        public ISupplierRepository Supplier { get; private set; }
    }
}
