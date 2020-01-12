using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ThreeAmigosPurchase.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public PurchaseService(HttpClient client, ILogger<PurchaseDto> logger)
        {
            client.BaseAddress = new System.Uri("https://third-party-orders-api.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Purchase
        public async Task<IEnumerable<PurchaseDto>> GetPurchaseAsync()
        {
            var response = await _client.GetAsync("orders/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<IEnumerable<PurchaseDto>>();
            return purchase;

        }

        //Get all Purchases
        public async Task<IEnumerable<PurchaseDto>> GetPurchasesAsync(int Id)
        {
            var response = await _client.GetAsync("orders/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<IEnumerable<PurchaseDto>>();
            return purchase;

        }

        //Get Individual Purchase Details
        public async Task<PurchaseDto> GetPurchaseDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("orders/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<PurchaseDto>();
            return purchase;
        }

        //Post New Purchase Member
        public async Task<PurchaseDto> PostPurchaseAsync(PurchaseDto purchases)
        {
            var response = await _client.PostAsJsonAsync("orders/", purchases);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<PurchaseDto>();
            return purchase;
        }

        //Put New Purchase Member
        public async Task<PurchaseDto> PutPurchaseAsync(PurchaseDto purchase)
        {
            var response = await _client.PutAsJsonAsync("orders/" + purchase.Id, purchase);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<PurchaseDto>();
        }

        //Edit Individual Purchase Details
        public async Task<PurchaseDto> EditPurchaseDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("orders/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<PurchaseDto>();
            return purchase;
        }

        //Get Edit Delete
        public async Task<PurchaseDto> GetDeletePurchaseAsync(int Id)
        {
            var response = await _client.GetAsync("orders/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<PurchaseDto>();
            return purchase;
        }

        //Delete
        public async Task<PurchaseDto> DeletePurchaseAsync(int Id)
        {
            var response = await _client.DeleteAsync("orders/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<PurchaseDto>();
            return purchase;
        }

        //Get Purchase Exists
        public bool GetPurchaseExists(int Id)
        {
            var response = _client.GetAsync("orders/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Purchase does not exist in the database");
                return false;
            }
            return true;
        }
    }
}
