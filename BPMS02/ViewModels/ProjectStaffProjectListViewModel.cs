using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class ProjectStaffProjectListViewModel
    {
        public IEnumerable<ProjectStaffProjectViewModel> ProjectStaffProjectViewModels { get; set; }
        public ProjectBriefInfo ProjectBriefInfo { get; set; }
    }
}
