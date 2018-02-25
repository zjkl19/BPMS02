using BPMS02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.IRepository
{
    public interface IStaffProjectRepository
    {
        Task<List<StaffProject>> StaffProjects { get; }

        Task CreateAsync(StaffProject staffProject);

        Task<List<StaffProject>> ListAsync();

        Task<StaffProject> QueryByIdAsync(Guid Id);

        Task EditAsync(StaffProject staffProject);

        Task<StaffProject> Delete(Guid Id);
    }
}
