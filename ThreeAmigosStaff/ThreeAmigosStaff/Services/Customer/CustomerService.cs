using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThreeAmigosCustomer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;

        public CustomerService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("http://localhost:5001/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        //Get all Customer
        public async Task<IEnumerable<CustomerDto>> GetCustomerAsync()
        {
            var response = await _client.GetAsync("Customer/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<IEnumerable<CustomerDto>>();
            return customer;

        }

        //Get all Customers
        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync(int Id)
        {
            var response = await _client.GetAsync("Customer/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<IEnumerable<CustomerDto>>();
            return customer;

        }

        //Get Individual Customer Details
        public async Task<CustomerDto> GetCustomerDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("Customer/details/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();
            return customer;
        }

        //Post New Customer Member
        public async Task<CustomerDto> PostCustomerAsync(CustomerDto customers)
        {
            var response = await _client.PostAsJsonAsync("Customer/", customers);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();
            return customer;
        }

        //Edit Individual Customer Details
        public async Task<CustomerDto> EditCustomerDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("Customer/edit/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();
            return customer;
        }

        //Get Edit Delete
        public async Task<CustomerDto> GetDeleteCustomerAsync(int Id)
        {
            var response = await _client.GetAsync("Customer/delete/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();
            return customer;
        }
    }
}
