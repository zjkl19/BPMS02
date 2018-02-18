using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Models
{
    /// <summary>
    /// 职工
    /// </summary>
    public class Staff
    {

        public Guid Id { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [Required]
        public int No { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MinLength(2),MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required]
        public int Gender { get; set; }

        /// <summary>
        /// 办公电话
        /// </summary>
        [MinLength(2), MaxLength(20)]
        public string OfficePhone { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        [Required]
        [MinLength(2), MaxLength(20)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [Required]
        public int Position { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        [Required]
        public int JobTitle { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [Required]
        public int Education { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        [Required]
        public DateTime HiredDate { get; set; }

        /// <summary>
        /// 1位职工可以承接n份合同
        /// </summary>
        [InverseProperty("AcceptStaff")]
        public virtual ICollection<Contract> AcceptContracts { get; set; }

        /// <summary>
        /// 1位职工可以负责n份合同
        /// </summary>
        [InverseProperty("ResponseStaff")]
        public virtual ICollection<Contract> ResponseContracts { get; set; }

        /// <summary>
        /// 1位职工参与n个项目
        /// </summary>
        public virtual ICollection<StaffProject> StaffProjects { get; set; }

    }
}
