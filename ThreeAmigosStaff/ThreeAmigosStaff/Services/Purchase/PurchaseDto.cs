using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeAmigosPurchase.Services
{
    public class PurchaseDto
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
        public int CardNumber { get; set; }
        public int SortCode { get; set; }
        public int SecurityNumber { get; set; }
    }
}