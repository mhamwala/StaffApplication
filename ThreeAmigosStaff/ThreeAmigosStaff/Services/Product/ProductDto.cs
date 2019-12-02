using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ThreeAmigosProduct.Services
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}