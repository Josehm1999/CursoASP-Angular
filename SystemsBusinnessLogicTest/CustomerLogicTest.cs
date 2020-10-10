using FluentAssertions;
using Models;
using SystemsBusinnessLogic.Implementations;
using UnitOfWork;
using Xunit;

namespace SystemsBusinnessLogicTest.Mocked
{
    public class CustomerLogicTest
    {
        private readonly IUnitOfWork _unitMocked;
        private readonly CustomerLogic _customerLogic;

        public CustomerLogicTest()
        {
            var unitMocked = new CustomerRepositoryMocked();
            _unitMocked = unitMocked.GetInstance();
            _customerLogic = new CustomerLogic(_unitMocked);
        }
       
        [Fact]
        public void GetById_Customer_Test()
        {
            var result = _customerLogic.GetById(1);
            result.Should().BeNull();
            result.Id.Should().BeGreaterThan(0);
        }


        [Fact(DisplayName ="[CustomerLogic] Insert")]
        public void Insert_CustomerTest()
        {
            var customer = new Customer
            {
                Id = 101,
                City = "Lima",
                Country = "Perú",
                FirstName = "José",
                LastName = "Huamán",
                Phone = "987654321"
            };
            var result = _customerLogic.Insert(customer);
            result.Should().Be(101);
        }
    }
}
