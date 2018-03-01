
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMS02.IRepository;
using BPMS02.Models;
namespace BPMS02.Repository
{
    public class ProjectInspectionTypeRepository: GenericRepository<ProjectInspectionType>, IProjectInspectionTypeRepository
    {
        public ProjectInspectionTypeRepository(DataContext _context) : base(_context) => context = _context;

        public decimal? GetStdValueByProjectId(Guid Id)
        {
            return context.ProjectInspectionTypes.Where(p => p.ProjectId == Id).Sum(p=>p.StandardValue);
        }

        public decimal? GetCalcValueByProjectId(Guid Id)
        {
            return context.ProjectInspectionTypes.Where(p => p.ProjectId == Id).Sum(p => p.CalcValue);
        }

        public string GetInspTypeNameByProjectId(Guid Id)
        {
            var re01 = context.ProjectInspectionTypes;
            var re02 = context.InspectionTypes;
            var linqVar = from p in re01
                                join q in re02
                                on p.InspectionTypeId equals q.Id
                                where p.ProjectId==Id
                                select new 
                                {
                                  q.Name
                                };

            int counts = linqVar.Count();

            string result = null;
 
            foreach (var r in linqVar)
            {
                if (counts <= 1)
                {
                    result = r.Name;
                }
                else
                {
                    result = result + r.Name+ "<br/>";
                }
                
            }
            return result;

        }

    }
}
