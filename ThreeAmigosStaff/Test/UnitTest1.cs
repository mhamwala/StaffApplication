using System;
using ThreeAmigosCustomer.Controllers;
using ThreeAmigosCustomer.Services;
using Xunit;

namespace Test
{
    public class CustomerControllerTest
    {
        CustomerController _customerController;
        ICustomerService _customerService;

        public CustomerControllerTest()
        {
            _customerService = new FakeCustomerService();
            _customerController = new CustomerController(_customerService);
        }

        public class UnitTest1
        {
            [Fact]
            public void Test1()
            {
                // Act
                var okResult = _customerController.Index();

                // Assert
                Assert.Equal(1, 1);
            }
        }
    }
}
