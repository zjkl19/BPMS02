using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Models
{
    /// <summary>
    /// 项目
    /// </summary>
    public class Project
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 检测类型
        /// </summary>
        public int InspectionType { get; set; }

        /// <summary>
        /// 标准产值
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? StandardValue { get; set; }

        /// <summary>
        /// 计算产值
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? CalcValue { get; set; }

        /// <summary>
        /// 进场进度
        /// </summary>
        public int EnterProgress { get; set; }

        /// <summary>
        /// 进场日期
        /// </summary>
        public DateTime? EnterDate { get; set; }

        /// <summary>
        /// 现场进度
        /// </summary>
        public int SiteProgress { get; set; }

        /// <summary>
        /// 现场完成日期
        /// </summary>
        public DateTime? SiteFinishedDate { get; set; }

        /// <summary>
        /// 退场日期
        /// </summary>
        public DateTime? ExitDate { get; set; }

        /// <summary>
        /// 报告进度
        /// </summary>
        public int ReportProgress { get; set; }

        /// <summary>
        /// 报告编号
        /// </summary>
        [MaxLength(20)]
        public string ReportNo { get; set; }

        /// <summary>
        /// 报告出具日期
        /// </summary>
        public DateTime? ReportPublishedDate { get; set; }

        /// <summary>
        /// 延期天数
        /// </summary>
        public int DelayDays { get; set; }

        /// <summary>
        /// 延期率
        /// </summary>
        public decimal DelayRate { get; set; }

        /// <summary>
        /// 项目进展情况说明
        /// </summary>
        public DateTime? ProjectProgressExplanation { get; set; }

        /// <summary>
        /// 1个项目只能关联1份合同
        /// </summary>
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// 1个项目只能检测1座桥梁
        /// </summary>
        public virtual Bridge Bridge { get; set; }

        /// <summary>
        /// 1个项目有n个检测类型
        /// </summary>
        public virtual ICollection<InspectionType> InspectionTypes { get; set; }

        /// <summary>
        /// 1个项目可以有n位职工参与
        /// </summary>
        public virtual ICollection<StaffProject> StaffProjects { get; set; }

        /// <summary>
        /// 1个项目可以有n种检测类型
        /// </summary>
        public virtual ICollection<ProjectInspectionType> ProjectInspectionTypes { get; set; }
    }
}
