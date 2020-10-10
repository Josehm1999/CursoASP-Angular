using Models;
using System.Collections.Generic;
using SystemsBusinnessLogic.Interfaces;
using UnitOfWork;

namespace SystemsBusinnessLogic.Implementations
{
    public class CustomerLogic: ICustomerLogic 
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Customer customer) => _unitOfWork.Customer.Delete(customer);

        public Customer GetById(int Id) => _unitOfWork.Customer.GetById(Id);

        public IEnumerable<Customer> GetList() => _unitOfWork.Customer.GetList();

        public int Insert(Customer customer) => _unitOfWork.Customer.Insert(customer);

        public bool Update(Customer customer) => _unitOfWork.Customer.Update(customer);

        IEnumerable<CustomerList> ICustomerLogic.GetPaginatedCustomer(int page, int rows) => _unitOfWork.Customer.CustomerPagedList(page, rows);
    }
}
