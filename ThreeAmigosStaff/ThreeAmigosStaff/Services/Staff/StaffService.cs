using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ThreeAmigosStaff.Services
{
    public class StaffService : IStaffService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public StaffService(HttpClient client, ILogger<StaffService> logger)
        {
            client.BaseAddress = new System.Uri("https://staffaccountapi.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Staff
        public async Task<IEnumerable<StaffDto>> GetStaffAsync()
        {
            var response = await _client.GetAsync("staffaccounts/");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("FAIling to do stuff.");
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<IEnumerable<StaffDto>>();
            return staff;
        }

        //Get Individual Staff Details
        public async Task<StaffDto> GetStaffDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("staffaccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<StaffDto>();
            return staff;
        }

        //Post New Staff Member
        public async Task<StaffDto> PostStaffAsync(StaffDto staffs)
        {
            var response = await _client.PostAsJsonAsync("staffaccounts/", staffs);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<StaffDto>();
            return staff;
        }

        //Put New Staff Member
        public async Task<StaffDto> PutStaffAsync(StaffDto staff)
        {
            var response = await _client.PutAsJsonAsync("staffaccounts/" + staff.Id, staff);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<StaffDto>();
        }

        //Edit Individual Staff Details
        public async Task<StaffDto> EditStaffDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("staffaccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<StaffDto>();
            return staff;
        }

        // GET: Delete staff
        public async Task<StaffDto> GetDeleteStaffAsync(int Id)
        {
            var response = await _client.GetAsync("staffaccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<StaffDto>();
            return staff;
        }

        //Delete
        public async Task<StaffDto> DeleteStaffAsync(int Id)
        {
            var response = await _client.DeleteAsync("staffaccounts/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<StaffDto>();
            return staff;
        }

        //Get Review Exists
        public bool GetStaffExists(int Id)
        {
            var response = _client.GetAsync("staffaccounts/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Staff does not exist in the database");
                return false;
            }
            return true;
        }
    }
}
