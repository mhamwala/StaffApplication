using Xunit;
using Xunit.Abstractions;

namespace CustomerApiUnitTests
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
        //    var dbContext = FakeDbContext.GetCustomerMockDb(nameof(postCustomer));
        //    var controller = new ThreeAmigosCustomer.Services.CustomerService(dbContext);

        //    //act
        //    var post = await controller.PostCustomerAsync(new ThreeAmigosCustomer.Services.CustomerDto() { Name = "Musa Haamwala", Email = "example@1.com", Password = "RomanticComedy", Address = "2 Tell close", PostCode = "JG3 5BD", Telephone = "09722342344" });

        //    //assert
        //    Xunit.Assert.IsType<ActionResult<product>>(post);
        //    Xunit.Assert.Equal("galaxy bar", post.Value.Name);
        //    Xunit.Assert.Equal(12.99, post.Value.Price);
        //    Xunit.Assert.Equal(42, post.Value.Stock);
        //    output.WriteLine("all products: {0} ", post.Value.Name);
        //}

        [Fact]
        public async void getProduct()
        {
            //assert
            var dbContext = FakeDbContext.GetCustomerMockDb(nameof(postProduct));
            var controller = new ThreeAmigosCustomer.Services.CustomerService(dbContext);

            //act
            var get = await controller.GetCustomersAsync(1);

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