using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CustomerApiUnitTests;
using manageProducts.Controllers;
using manageProducts.Interfaces;
using manageProducts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Abstractions;

namespace manage_products_api_unit_tests.unit_tests
{
    public class product_tests
    {
        private readonly ITestOutputHelper output;

        public product_tests(ITestOutputHelper output)
        {
            this.output = output;

        }

        [Fact]
        public async void postProduct()
        {
            //assert
            var dbContext = FakeDbContext.getCustomerMockDb(nameof(postCustomer));
            var controller = new productsController(dbContext);

            //act
            var post = await controller.Postproduct(new product() { Name = "galaxy bar", Price = 12.99, Stock = 42 });

            //assert
            Xunit.Assert.IsType<ActionResult<product>>(post);
            Xunit.Assert.Equal("galaxy bar", post.Value.Name);
            Xunit.Assert.Equal(12.99, post.Value.Price);
            Xunit.Assert.Equal(42, post.Value.Stock);
            output.WriteLine("all products: {0} ", post.Value.Name);
        }

        [Fact]
        public async void getProduct()
        {
            //assert
            var dbContext = fakeDbContext.getProductMockDb(nameof(postProduct));
            var controller = new productsController(dbContext);

            //act
            var get = await controller.Getproduct(1);

            //assert
            Xunit.Assert.IsType<ActionResult<product>>(get);
            //Xunit.Assert.Equal("galaxy bar", get.Value.Name);
            output.WriteLine("all products: {0} ", get.Value.Name);
        }

        [Fact]
        public void test()
        {
            output.WriteLine("test output {0}", " test eetst test test etest ");
            Xunit.Assert.Equal(1, 1);
        }
    }
}