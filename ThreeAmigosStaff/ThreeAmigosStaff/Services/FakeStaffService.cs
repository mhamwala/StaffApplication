using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigosStaff.Services
{
    public class FakeStaffService : IStaffService
    {
        private readonly StaffDto[] _staff =
        {
            new StaffDto { Id = 1, Name = "Musa Hamwala", Address = "4 d road", Email = "Musa@hot.com", IsManagement = true, PostCode = "HU27fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 2, Name = "Barry Hamwala", Address = "4 de road", Email = "Musa@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 3, Name = "Barry Hamwala", Address = "4 de road", Email = "Musa@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 4, Name = "Barry Hamwala", Address = "4 de road", Email = "Musa@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 5, Name = "Barry Hamwala", Address = "4 de road", Email = "Musa@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 6, Name = "Barry Hamwala", Address = "4 de road", Email = "Musa@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"}
        };

        public Task<IEnumerable<StaffDto>> GetStaffAsync()
        {
            return Task.FromResult(_staff.AsEnumerable());
        }

        Task<StaffDto> IStaffService.GetStaffDetailsAsync(int Id)
        {
            var staff = _staff.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(staff);
        }
    }
}
