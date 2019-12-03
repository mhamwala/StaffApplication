using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ThreeAmigosCustomer.Services
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Telephone { get; set; }
    }
}