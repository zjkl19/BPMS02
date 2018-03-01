using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BPMS02.ViewModels
{
    public class CreateProjectViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "关联合同名称")]
        public string ContractName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "项目名称")]
        public string Name { get; set; }

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

        [Display(Name = "项目进度说明")]
        public string ProjectProgressExplanation { get; set; }


        [HiddenInput]
        public Guid ContractId { get; set; }

        [HiddenInput]
        public Guid BridgeId { get; set; }

        [Display(Name = "桥梁名称")]
        public string BridgeName { get; set; }

    }

}
