using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BPMS02.Models;

namespace BPMS02.IRepository
{
    public interface IProjectInspectionTypeRepository : IBasicCRUDRepository<ProjectInspectionType>
    {
        decimal? GetStdValueByProjectId(Guid Id);

        decimal? GetCalcValueByProjectId(Guid Id);

        string GetInspTypeNameByProjectId(Guid Id);
    }
}
