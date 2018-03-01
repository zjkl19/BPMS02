using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    public class ProjectBriefInfo
    {

        [Display(Name = "项目数量")]
        public int TotalItems { get; set; }
        [Display(Name = "标准产值")]
        public decimal? TotalStdValue { get; set; }
        [Display(Name = "计算产值")]
        public decimal? TotalCalcValue { get; set; }
    }
}
