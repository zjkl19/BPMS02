using BPMS02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.IRepository
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> QueryByNo(int No);
        //IEnumerable<Staff> Staffs { get; }
        Task CreateAsync(Staff staff);

        Task<List<Staff>> Staffs { get; }
        Task<List<Staff>> ListAsync();

        Task<Staff> QueryByIdAsync(Guid Id);

        Task <List<Staff>> QueryByNoAsync(int? No);

        Task<List<Staff>> QueryByNameAsync(string Name);

        Task EditAsync(Staff staff);

        Task<Staff> DeleteStaff(Guid Id);
    }
}
