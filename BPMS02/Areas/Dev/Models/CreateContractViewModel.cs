using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BPMS02.Models;

namespace BPMS02.Areas.Dev.Models
{
    public class CreateContractViewModel
    {

        [Required]
        [Remote(action: "VerifyContractNo", controller: "Contract")]
        [Display(Name = "合同编号")]
        public string No { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "合同名称")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "合同金额")]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "合同签订日期")]
        [DataType(DataType.Date)]
        public DateTime SignedDate { get; set; }

        [Required]
        [Display(Name = "合同期限")]
        public int Deadline { get; set; }

        [Required]
        [Display(Name = "合同负责人约定期限")]
        public int PromisedDeadline { get; set; }

        [Required]
        [Display(Name = "合同约定工作内容")]
        public string JobContent { get; set; }

        [Required]
        [Display(Name = "项目地点")]
        [MaxLength(30)]
        public string ProjectLocation { get; set; }

        [Required]
        [Display(Name = "委托单位")]
        [MaxLength(30)]
        public string Client { get; set; }

        [Required]
        [Display(Name = "委托单位联系人")]
        [StringLength(50)]
        public string ClientContactPerson { get; set; }

        [Required]
        [Display(Name = "委托单位联系人电话")]
        [MaxLength(20)]
        public string ClientContactPersonPhone { get; set; }

        [Required]
        [Display(Name = "承接方式")]
        public AcceptWay AcceptWay { get; set; }

        [Required]
        [Display(Name = "合同签订状态")]
        public SignStatus SignStatus { get; set; }

        [Required]
        //[HiddenInput]
        [Display(Name = "合同承接人")]
        public Guid AcceptStaffId { get; set; }

        [Display(Name = "承接人姓名")]
        public string AcceptStaffName { get; set; }

        [Required]
        //[HiddenInput]
        [Display(Name = "合同负责人")]
        public Guid ResponseStaffId { get; set; }

        [Display(Name = "合同负责人姓名")]
        public string ResponseStaffName { get; set; }
    }
}
