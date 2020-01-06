using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeAmigosCustomer.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomerAsync();

        Task<IEnumerable<CustomerDto>> GetCustomersAsync(int Id);

        Task<CustomerDto> GetCustomerDetailsAsync(int Id);

        Task<CustomerDto> PostCustomerAsync(CustomerDto CustomerDto);

        Task<CustomerDto> EditCustomerDetailsAsync(int Id);

        Task<CustomerDto> GetDeleteCustomerAsync(int Id);

        Task<CustomerDto> DeleteCustomerAsync(int Id);
    }
}
