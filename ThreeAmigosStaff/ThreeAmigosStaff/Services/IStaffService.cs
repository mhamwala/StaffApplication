using System;
using System.Threading.Tasks;

namespace ThreeAmigosStaff.Services
{
    public interface IStaffService
    {
        Task<StaffDto> GetStaffAsync();
    }
}
