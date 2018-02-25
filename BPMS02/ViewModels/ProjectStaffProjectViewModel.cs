using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.ViewModels
{
    /// <summary>
    /// 指定项目：职工参与情况
    /// </summary>
    public class ProjectStaffProjectViewModel
    {
        /// <summary>
        /// 指的是StaffProjects表中对应的Id
        /// </summary>
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "参与人员")]
        public string StaffName { get; set; }

        [Display(Name="分工")]
        public Labor Labor { get; set; }

        [Display(Name = "产值比例")]
        public decimal? Ratio { get; set; }

        [Display(Name = "标准产值")]
        [Column(TypeName = "money")]
        public decimal? StandardValue { get; set; }

        [Display(Name = "计算产值")]
        [Column(TypeName = "money")]
        public decimal? CalcValue { get; set; }

    }
    public enum Labor
    {
        [Display(Name = "项目负责")]
        response = 1,
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
