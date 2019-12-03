using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ThreeAmigosCustomer.Services
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}