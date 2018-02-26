using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class ProjectStaffProjectListViewModel
    {
        /// <summary>
        /// 项目Id
        /// </summary>
        public Guid ProjectId;

        /// <summary>
        /// 视图中显示的项目名称
        /// </summary>
        [Display(Name="项目名称")]
        public string ProjectName;
        public IEnumerable<ProjectStaffProjectViewModel> ProjectStaffProjectViewModels { get; set; }
        public ProjectBriefInfo ProjectBriefInfo { get; set; }
    }
}
