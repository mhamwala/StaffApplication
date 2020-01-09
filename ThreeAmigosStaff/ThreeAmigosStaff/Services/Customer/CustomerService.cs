using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ThreeAmigosCustomer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public CustomerService(HttpClient client, ILogger<CustomerService> logger)
        {
            client.BaseAddress = new System.Uri("https://customeraccountapi.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Customer
        public async Task<IEnumerable<CustomerDto>> GetCustomerAsync()
        {
            var response = await _client.GetAsync("customeraccounts/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("FAIling to get all customers.");
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<IEnumerable<CustomerDto>>();
            return customer;

        }

        //Get all Customers
        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync(int Id)
        {
            var response = await _client.GetAsync("customeraccounts/" + Id);
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
            var response = await _client.GetAsync("customeraccounts/" + Id);
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
            var response = await _client.PostAsJsonAsync("customeraccounts/", customers);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();
            return customer;
        }

        //Put New Order Member
        public async Task<CustomerDto> PutCustomerAsync(CustomerDto customer)
        {
            var response = await _client.PutAsJsonAsync("customeraccounts/" + customer.Id, customer);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<CustomerDto>();
        }

        //Edit Individual Customer Details
        public async Task<CustomerDto> EditCustomerDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("customeraccounts/" + Id);
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
            var response = await _client.DeleteAsync("customeraccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();
            return customer;
        }

        //Delete
        public async Task<CustomerDto> DeleteCustomerAsync(int Id)
        {
            var response = await _client.DeleteAsync("customeraccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<CustomerDto>();
            return customer;
        }

        //Get Customer Exists
        public bool GetCustomerExists(int Id)
        {
            var response = _client.GetAsync("customeraccounts/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Customer does not exist in the database");
                return false;
            }
            return true;
        }
    }
}
