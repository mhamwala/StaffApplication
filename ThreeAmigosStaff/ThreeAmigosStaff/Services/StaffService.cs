using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThreeAmigosStaff.Services
{
    public class StaffService : IStaffService
    {
        private readonly HttpClient _client;

        public StaffService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("http://localhost:5001/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IEnumerable<StaffDto>> GetStaffAsync()
        {
            var response = await _client.GetAsync("staff/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var staff = await response.Content.ReadAsAsync<IEnumerable<StaffDto>>();
            return staff;

        }

        public async Task<StaffDto> GetStaffDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("staff/details/" + Id);
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
