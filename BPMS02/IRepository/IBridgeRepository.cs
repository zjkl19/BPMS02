using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.Models;

namespace BPMS02.IRepository
{
    public interface IBridgeRepository
    {
        Task<List<Bridge>> Bridges { get; }

        Task CreateAsync(Bridge bridge);

        Task<List<Bridge>> ListAsync();

        Task<Bridge> QueryByIdAsync(Guid Id);

        Task<List<Bridge>> QueryByNameAsync(string Name);

        Task EditAsync(Bridge bridge);

        Task<Bridge> Delete(Guid Id);
    }
}
