using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Models;

namespace BPMS02.IRepository
{
    public interface IProjectRepository : IBasicCRUDRepository<Project>
    {
        Task<List<Project>> QueryByNameAsync(string Name);

    }
}
