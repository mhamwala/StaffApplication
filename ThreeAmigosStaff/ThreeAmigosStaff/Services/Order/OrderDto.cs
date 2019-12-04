using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeAmigosOrder.Services
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public double Total { get; set; }
        public int Quantity { get; set; }
        public string ShippingAddress { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShippingDate { get; set; }
    }
}