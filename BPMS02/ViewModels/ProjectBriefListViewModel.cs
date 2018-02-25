using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class ProjectBriefListViewModel
    {
        public IEnumerable<ProjectBriefViewModel> ProjectBriefViewModels { get; set; }
        public ProjectBriefInfo ProjectBriefInfo { get; set; }
    }
}
