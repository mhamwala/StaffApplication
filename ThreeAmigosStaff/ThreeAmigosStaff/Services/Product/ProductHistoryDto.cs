using System;

namespace ThreeAmigosProduct.Services
{
    public class ProductHistoryDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public DateTime DateChange { get; set; }
        public double Price { get; set; }
    }
}