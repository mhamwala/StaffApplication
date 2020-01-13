using ThreeAmigosProduct.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Products
{
    public static class seedData
    {
        public static void Seed(this productsContext dbContext)
        {
            dbContext.product.AddRange(
                new ProductDto() { Name = "galaxy bar", Price = 12.99, Stock = 42 },
                new ProductDto() { Name = "20kg galaxy bar", Price = 12.99, Stock = 42 },
                new ProductDto() { Name = "20kg galaxy bar", Price = 12.99, Stock = 42 },
                new ProductDto() { Name = "20kg galaxy bar", Price = 12.99, Stock = 42 }
                );

            dbContext.productHistory.AddRange(
                new ProductHistoryDto() { ProductId = 0, DateChange = DateTime.Now, Price = 12.99 },
                new ProductHistoryDto() { ProductId = 1, DateChange = DateTime.Now, Price = 12.99 },
                new ProductHistoryDto() { ProductId = 2, DateChange = DateTime.Now, Price = 12.99 },
                new ProductHistoryDto() { ProductId = 3, DateChange = DateTime.Now, Price = 12.99 }
                );

            dbContext.review.AddRange(
                new ReviewDto() { CustomerID = 0, ProductID = 32, Rating = 3, Comments = "fab", Visible = true },
                new ReviewDto() { CustomerID = 1, ProductID = 2, Rating = 5, Comments = "perfect", Visible = true },
                new ReviewDto() { CustomerID = 2, ProductID = 34, Rating = 1, Comments = "not to good", Visible = false }
                );

            dbContext.SaveChanges();
        }
    }
}
