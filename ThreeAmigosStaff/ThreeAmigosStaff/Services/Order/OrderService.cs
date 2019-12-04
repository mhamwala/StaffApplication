using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThreeAmigosOrder.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("http://localhost:5001/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        //Get all Order
        public async Task<IEnumerable<OrderDto>> GetOrderAsync()
        {
            var response = await _client.GetAsync("Order/");
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
            var response = await _client.GetAsync("Order/" + Id);
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
            var response = await _client.GetAsync("Order/details/" + Id);
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
            var response = await _client.PostAsJsonAsync("Order/", orders);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }

        //Edit Individual Order Details
        public async Task<OrderDto> EditOrderDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("Order/edit/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<OrderDto>();
            return order;
        }

        //Get Edit Delete
        public async Task<OrderDto> GetDeleteOrderAsync(int Id)
        {
            var response = await _client.GetAsync("Order/delete/" + Id);
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
