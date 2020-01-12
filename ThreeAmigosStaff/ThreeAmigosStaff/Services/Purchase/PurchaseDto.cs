using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeAmigosPurchase.Services
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int productID { get; set; }
        public double ProductQuantity { get; set; }
        public bool status { get; set; }
    }
}