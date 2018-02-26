using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class ProjectBriefListViewModel
    {
        /// <summary>
        /// 关联合同Id
        /// </summary>
        public Guid ContractId { get; set; }
        public IEnumerable<ProjectBriefViewModel> ProjectBriefViewModels { get; set; }
        public ProjectBriefInfo ProjectBriefInfo { get; set; }
    }
}
