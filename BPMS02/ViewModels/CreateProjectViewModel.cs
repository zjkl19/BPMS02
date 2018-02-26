using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPMS02.ViewModels
{
    public class CreateProjectViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "项目名称")]
        public string Name { get; set; }

        [Display(Name = "创建时间")]
        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }

        [Display(Name = "标准产值")]
        [Column(TypeName = "money")]
        public decimal? StandardValue { get; set; }

        [Display(Name = "计算产值")]
        [Column(TypeName = "money")]
        public decimal? CalcValue { get; set; }

        [Display(Name = "进场进度")]
        public EnterProgress EnterProgress { get; set; }

        [Display(Name = "进场日期")]
        [DataType(DataType.Date)]
        public DateTime? EnterDate { get; set; }

        [Display(Name = "现场进度")]
        public SiteProgress SiteProgress { get; set; }

        [Display(Name = "现场完成日期")]
        [DataType(DataType.Date)]
        public DateTime? SiteFinishedDate { get; set; }

        [Display(Name = "退场日期")]
        [DataType(DataType.Date)]
        public DateTime? ExitDate { get; set; }

        [Display(Name = "报告进度")]
        public ReportProgress ReportProgress { get; set; }

        [Display(Name = "报告编号")]
        [MaxLength(20)]
        public string ReportNo { get; set; }

        [Display(Name = "报告出具日期")]
        [DataType(DataType.Date)]
        public DateTime? ReportPublishedDate { get; set; }

        [Display(Name = "延期天数")]
        public int DelayDays { get; set; }

        [Display(Name = "延期率")]
        public decimal DelayRate { get; set; }

        [Display(Name = "项目进度说明")]
        public string ProjectProgressExplanation { get; set; }


        public Guid ContractId { get; set; }

        public Guid BridgeId { get; set; }

    }

}
