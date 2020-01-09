using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigosCustomer.Services
{
    public class FakeCustomerService : ICustomerService
    {
        public List<CustomerDto> _customer = new List<CustomerDto>
        {
            new CustomerDto { Name = "Musa Haamwala", Email = "example@1.com", Password = "RomanticComedy", Address = "2 Tell close", PostCode = "JG3 5BD", Telephone = "09722342344" },
            new CustomerDto { Name = "Usas Haamwala", Email = "example@3.com", Password = "RomanticComedy", Address = "5 Tell close", PostCode = "JG3 5BD", Telephone = "09722342344" },
            new CustomerDto { Name = "Pkmd Haamwala", Email = "example@2.com", Password = "RomanticComedy", Address = "6 Tell close", PostCode = "JG3 5BD", Telephone = "09723342344" },
            new CustomerDto { Name = "Lsoij Haamwala", Email = "example@5.com", Password = "RomanticComedy", Address = "5 Tell close", PostCode = "JG3 5BD", Telephone = "09724342344" }
        };

        public Task<IEnumerable<CustomerDto>> GetCustomerAsync()
        {
            return Task.FromResult(_customer.AsEnumerable());
        }

        Task<CustomerDto> ICustomerService.GetCustomerDetailsAsync(int Id)
        {
            var customer = _customer.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        Task<CustomerDto> ICustomerService.PostCustomerAsync(CustomerDto customer)
        {
            _customer.Add(customer);
            return Task.FromResult(customer);
        }

        Task<CustomerDto> ICustomerService.PutCustomerAsync(CustomerDto customer)
        {
            _customer.Add(customer);
            return Task.FromResult(customer);
        }

        Task<CustomerDto> ICustomerService.EditCustomerDetailsAsync(int Id)
        {
            var customer = _customer.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        public Task<CustomerDto> GetDeleteCustomerAsync(int Id)
        {
            var customer = _customer.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        public Task<IEnumerable<CustomerDto>> GetCustomersAsync(int Id)
        {
            return Task.FromResult(_customer.AsEnumerable());
        }

        public Task<CustomerDto> DeleteOrderAsync(int Id)
        {
            var customer = _customer.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        public Task<CustomerDto> DeleteCustomerAsync(int Id)
        {
            var customer = _customer.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(customer);
        }

        public bool GetCustomerExists(int Id)
        {
            return true;
        }
    }
}
