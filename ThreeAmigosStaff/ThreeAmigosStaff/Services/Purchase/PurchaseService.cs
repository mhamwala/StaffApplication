using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThreeAmigosPurchase.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly HttpClient _client;

        public PurchaseService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("https://managepurchasesapi.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        //Get all Purchase
        public async Task<IEnumerable<PurchaseDto>> GetPurchaseAsync()
        {
            var response = await _client.GetAsync("Purchase/");
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
            var response = await _client.GetAsync("Purchase/" + Id);
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
            var response = await _client.GetAsync("Purchase/details/" + Id);
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
            var response = await _client.PostAsJsonAsync("Purchase/", purchases);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<PurchaseDto>();
            return purchase;
        }

        //Edit Individual Purchase Details
        public async Task<PurchaseDto> EditPurchaseDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("Purchase/edit/" + Id);
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
            var response = await _client.GetAsync("Purchase/delete/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var purchase = await response.Content.ReadAsAsync<PurchaseDto>();
            return purchase;
        }
    }
}
