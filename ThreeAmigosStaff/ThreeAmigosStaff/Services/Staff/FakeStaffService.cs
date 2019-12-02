using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigosStaff.Services
{
    public class FakeStaffService : IStaffService
    {
        public List<StaffDto> _staff = new List<StaffDto>
        {
            new StaffDto { Id = 1, Name = "Musa Smith", Address = "4 d road", Email = "Smith@hot.com", IsManagement = true, PostCode = "HU27fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 2, Name = "Steve Smith", Address = "4 de road", Email = "Smith@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 3, Name = "John Smith", Address = "4 de road", Email = "Smith@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 4, Name = "Greg Smith", Address = "4 de road", Email = "Smith@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 5, Name = "Barry Smith", Address = "4 de road", Email = "Smith@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"},
            new StaffDto { Id = 6, Name = "Lewis Smith", Address = "4 de road", Email = "Smith@ht.com", IsManagement = false, PostCode = "HU57fv", Password = "test", Telephone = "08323894283"}
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

        Task<StaffDto> IStaffService.PostStaffAsync(StaffDto staff)
        {
            _staff.Add(staff);
            return Task.FromResult(staff);
        }

        Task<StaffDto> IStaffService.EditStaffDetailsAsync(int Id)
        {
            var staff = _staff.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(staff);
        }

        public Task<StaffDto> GetDeleteStaffAsync(int Id)
        {
            var staff = _staff.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(staff);
        }
    }
}
