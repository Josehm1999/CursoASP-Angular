using Models;
using System.Collections.Generic;

namespace SystemsBusinnessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        Customer GetById(int Id);
        IEnumerable<CustomerList> GetPaginatedCustomer(int page, int rows);
        IEnumerable<Customer> GetList(); 
        int Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(Customer customer);
    }
}
