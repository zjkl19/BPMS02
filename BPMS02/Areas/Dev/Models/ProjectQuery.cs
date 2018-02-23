using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class ProjectQuery
    {
        [Display(Name = "项目名称")]
        public string Name { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime? EnterDateBefore { get; set; }
        [Display(Name = "进场日期")]
        [DataType(DataType.Date)]
        public DateTime? EnterDateAfter { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime? SiteFinishedDateBefore { get; set; }
        [Display(Name = "现场完成日期")]
        [DataType(DataType.Date)]
        public DateTime? SiteFinishedDateAfter { get; set; }


        [Display(Name = "报告进度")]
        public ReportProgressQuery ReportProgressQuery { get; set; }

    }
    public enum ReportProgressQuery
    {
        [Display(Name = "任意")]
        all = int.MaxValue,
        [Display(Name = "未完成")]
        notFinished = 1,
        [Display(Name = "已完成")]
        finished = 2
    }

}
