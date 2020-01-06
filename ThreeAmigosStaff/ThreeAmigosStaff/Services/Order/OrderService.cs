using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ThreeAmigosOrder.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public OrderService(HttpClient client, ILogger<OrderService> logger)
        {
            client.BaseAddress = new System.Uri("https://customerorderapi.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Order
        public async Task<IEnumerable<OrderDto>> GetOrderAsync()
        {
            var response = await _client.GetAsync("ordersservice/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<IEnumerable<OrderDto>>();
            return order;

        }

        //Get all Orders
        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int Id)
        {
            var response = await _client.GetAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<IEnumerable<OrderDto>>();
            return order;

        }

        //Get Individual Order Details
        public async Task<OrderDto> GetOrderDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }

        //Post New Order Member
        public async Task<OrderDto> PostOrderAsync(OrderDto orders)
        {
            var response = await _client.PostAsJsonAsync("ordersservice/", orders);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }

        //Put New Order Member
        public async Task<OrderDto> PutOrderAsync(OrderDto order)
        {
            var response = await _client.PutAsJsonAsync("ordersservice/edit", order.Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<OrderDto>();
        }

        //Edit Individual Order Details
        public async Task<OrderDto> EditOrderDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }

        //Get Delete
        public async Task<OrderDto> GetDeleteOrderAsync(int Id)
        {
            var response = await _client.GetAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }

        //Delete
        public async Task<OrderDto> DeleteOrderAsync(int Id)
        {
            var response = await _client.DeleteAsync("ordersservice/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }
    }
}
