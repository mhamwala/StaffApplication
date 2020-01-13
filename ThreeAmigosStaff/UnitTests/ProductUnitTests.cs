using ThreeAmigosProduct.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
using ThreeAmigosProduct.Controllers;
using System.Threading.Tasks;

namespace UnitTests.Products
{
    public class product_tests
    {
        private readonly ITestOutputHelper output;

        public product_tests(ITestOutputHelper output)
        {
            this.output = output;

        }

        //[Fact]
        //public async void postProduct()
        //{
        //    //assert
        //    var dbContext = FakeDbContext.getProductMockDb(nameof(postProduct));
        //    var controller = new ProductController(dbContext);

        //    //act
        //    var post = await controller.Resell(new ProductDto() { Name = "galaxy bar", Price = 12.99, Stock = 42 });

        //    //assert
        //    Xunit.Assert.IsType<ActionResult<ProductDto>>(post);
        //    Xunit.Assert.Equal("galaxy bar", post.Name);
        //    Xunit.Assert.Equal(12.99, post.Price);
        //    Xunit.Assert.Equal(42, post.Stock);
        //    output.WriteLine("all products: {0} ", post.Name);
        //}

        //[Fact]
        //public void TestDetailsView()
        //{
        //    var controller = new ProductController(dbContext);
        //    var result = controller.Details(2) as ViewResult;
        //    var product = (Product)result.ViewData.Model;
        //    Assert.AreEqual("Laptop", product.Name);

        //}

        //[Fact]
        //public async void getProduct()
        //{
        //    //assert
        //    var dbContext = FakeDbContext.getProductMockDb(nameof(getProduct));
        //    var controller = new ProductController(dbContext);

        //    //act
        //    var get = await controller.Index() as Task<IActionResult>;

        //    //assert
        //    //Xunit.Assert.IsType<ActionResult<ProductDto>>(get);
        //    Xunit.Assert.Equal("galaxy bar", get.);
        //    output.WriteLine("all products: {0} ", get.Name);
        //}

        [Fact]
        public void test()
        {
            output.WriteLine("test output {0}", " test eetst test test etest ");
            Xunit.Assert.Equal(1, 1);
        }
    }
}
