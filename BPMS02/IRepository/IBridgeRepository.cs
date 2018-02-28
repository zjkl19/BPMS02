using BPMS02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.IRepository
{
    public interface IBridgeRepository:IBasicCRUDRepository<Bridge>
    {
        Task<List<Bridge>> QueryByNameAsync(string Name);
    }
}
