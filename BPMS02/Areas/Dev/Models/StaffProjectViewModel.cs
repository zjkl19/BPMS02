using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class StaffProjectViewModel
    {
        public Guid Id { get; set; }

        [Display(Name="分工")]
        public int Labor { get; set; }

        [Display(Name= "产值比例")]
        public decimal? Ratio { get; set; }

        [Display(Name = "标准产值")]
        [Column(TypeName = "money")]
        public decimal? StandardValue { get; set; }

        [Display(Name = "计算产值")]
        [Column(TypeName = "money")]
        public decimal? CalcValue { get; set; }

        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

    }
    public enum Labor
    {
        [Display(Name = "项目负责")]
        response= 1,
        [Display(Name = "现场检测")]
        siteWorking = 2,
        [Display(Name = "报告撰写")]
        reportWriting = 3,
        [Display(Name = "报告校核")]
        reportChecking = 4,
        [Display(Name = "数据分析")]
        dataAnalyse = 5,
    }
}
