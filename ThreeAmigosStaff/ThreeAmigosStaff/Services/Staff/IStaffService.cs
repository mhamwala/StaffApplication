using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeAmigosStaff.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<StaffDto>> GetStaffAsync();

        Task<StaffDto> GetStaffDetailsAsync(int Id);

        Task<StaffDto> PostStaffAsync(StaffDto staffDto);

        Task<StaffDto> EditStaffDetailsAsync(int Id);

        Task<StaffDto> GetDeleteStaffAsync(int Id);

        Task<StaffDto> DeleteStaffAsync(int Id);
    }
}
