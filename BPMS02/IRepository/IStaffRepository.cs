using BPMS02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.IRepository
{
    public interface IStaffRepository:IBasicCRUDRepository<Staff>
    {
        Task <List<Staff>> QueryByNoAsync(int? No);

        Task<List<Staff>> QueryByNameAsync(string Name);


    }
}
