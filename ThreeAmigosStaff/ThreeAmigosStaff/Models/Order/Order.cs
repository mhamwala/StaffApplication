using System;
using System.ComponentModel.DataAnnotations;
namespace MvcOrder.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public double Total { get; set; }
        public int Quantity { get; set; }
        public string ShippingAddress { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShippingDate { get; set; }
    }
}