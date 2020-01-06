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
            client.BaseAddress = new System.Uri("http://manage-staff-api/api/");
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
            var response = await _client.GetAsync("staffaccounts/details/" + Id);
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

        //Edit Individual Staff Details
        public async Task<StaffDto> EditStaffDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("staffaccounts/edit/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<StaffDto>();
            return staff;
        }

        //Delete staff
        public async Task<StaffDto> GetDeleteStaffAsync(int Id)
        {
            var response = await _client.GetAsync("staffaccounts/delete/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<StaffDto>();
            return staff;
        }
    }
}
