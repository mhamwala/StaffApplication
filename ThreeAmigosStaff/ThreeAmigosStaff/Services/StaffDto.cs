using System;
using System.ComponentModel.DataAnnotations;
namespace ThreeAmigosStaff.Services
{
    public class StaffDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Telephone { get; set; }
        public Boolean IsManagement { get; set; }
    }
}