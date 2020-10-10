﻿using AutoFixture;
using Models;
using Moq;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using UnitOfWork;

namespace SystemsBusinnessLogicTest.Mocked
{
    public class CustomerRepositoryMocked
    {
        private readonly List<Customer> _customers;
        public CustomerRepositoryMocked()
        {
            _customers = Customers();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Customer).Returns(GetCustomerRepositoryMocked());
            return mocked.Object;
        }
        public ICustomerRepository GetCustomerRepositoryMocked()
        {
            var customerMocked = new Mock<ICustomerRepository>();
            customerMocked.Setup(c => c.GetById(It.IsAny<int>()))
                          .Returns((int id) => _customers.FirstOrDefault(cus => cus.Id == id));
            customerMocked.Setup(c => c.Insert(It.IsAny<Customer>()))
                                .Callback<Customer>(c => _customers.Add(c))
                                .Returns<Customer>(c => c.Id);
            return customerMocked.Object;
        }
        private List<Customer> Customers()
        {
            var fixture = new Fixture();
            var customers = fixture.CreateMany<Customer>(50).ToList();
            for(int i=0; i<50; i++)
            {
                customers[i].Id = i + 1;
            }
            return customers;
        }
    }
}
