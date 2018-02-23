using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Models;

namespace BPMS02.IRepository
{
    public interface IProjectRepository
    {
        IEnumerable<Project> Projects { get; }

        Task CreateAsync(Project project);

        Task<List<Project>> ListAsync();

        Task<Project> QueryByIdAsync(Guid Id);

        //Task<List<Project>> QueryByNameAsync(string Name);

        Task EditAsync(Project project);

        Task<Project> Delete(Guid Id);
    }
}
