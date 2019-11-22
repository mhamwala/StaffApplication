using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPurchase.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public int Date { get; set; }
        public Boolean Accepted { get; set; }
    }
}
