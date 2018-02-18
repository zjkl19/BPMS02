using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPMS02.Models
{
    /// <summary>
    /// 合同
    /// </summary>
    public class Contract
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public string No { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime SignedDate { get; set; }

        /// <summary>
        /// 期限
        /// </summary>
        public int Deadline { get; set; }

        /// <summary>
        /// 合同负责人约定期限
        /// </summary>
        public int PromisedDeadline { get; set; }

        /// <summary>
        /// 工作内容
        /// </summary>
        public string JobContent { get; set; }

        /// <summary>
        /// 项目地点
        /// </summary>
        [MaxLength(30)]
        public string ProjectLocation { get; set; }

        /// <summary>
        /// 委托单位
        /// </summary>
        [StringLength(100)]
        public string Client { get; set; }

        /// <summary>
        /// 委托单位联系人
        /// </summary>
        [StringLength(50)]
        public string ClientContactPerson { get; set; }

        /// <summary>
        /// 委托单位联系人电话
        /// </summary>
        [MaxLength(20)]
        public string ClientContactPersonPhone { get; set; }

        /// <summary>
        /// 承接方式
        /// </summary>
        public int AcceptWay { get; set; }

        /// <summary>
        /// 合同签订状态
        /// </summary>
        public int SignStatus { get; set; }

        /// <summary>
        /// 1份合同只能由1位职工承接
        /// </summary>
        [InverseProperty("AcceptContracts")]
        public virtual Staff AcceptStaff { get; set; }

        /// <summary>
        /// 1份合同只能由1位职工负责
        /// </summary>
        [InverseProperty("ResponseContracts")]
        public virtual Staff ResponseStaff { get; set; }

        /// <summary>
        /// 1份合同可以开具n张发票
        /// </summary>
        public virtual ICollection<Invoice> Invoices { get; set; }

        /// <summary>
        /// 1份合同含有n个项目
        /// </summary>
        public virtual ICollection<Project> Projects { get; set; }


    }
}
