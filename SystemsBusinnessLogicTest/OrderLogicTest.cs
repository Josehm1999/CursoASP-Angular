using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using SystemsBusinnessLogic.Implementations;
using SystemsBusinnessLogicTest.Mocked;
using UnitOfWork;
using Xunit;

namespace SystemsBusinnessLogicTest
{
    public class OrderLogicTest
    {
        private readonly IUnitOfWork _unitMocked;
        private readonly OrderLogic _orderLogic;

        public OrderLogicTest()
        {
            var unitMocked = new OrderRepositoryMocked();
            _unitMocked = unitMocked.GetIntance();
            _orderLogic = new OrderLogic(_unitMocked);
        }

        [Fact]
        public void GetOrderNumber_Test()
        {
            var result = _orderLogic.GetOrderNumber(1);
            result.Should().NotBeNullOrEmpty();
        }
    }
}
