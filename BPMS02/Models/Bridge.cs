using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Models
{
    /// <summary>
    /// 桥梁
    /// </summary>
    public class Bridge
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 桥梁长度
        /// </summary>
        [Required]
        public double Length { get; set; }

        /// <summary>
        /// 桥梁宽度
        /// </summary>
        [Required]
        public double Width { get; set; }

        /// <summary>
        /// 桥梁跨数
        /// </summary>
        [Required]
        public int SpanNumber { get; set; }

        /// <summary>
        /// 结构形式
        /// </summary>
        [Required]
        public int StructureType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// 1座桥梁可以在n个检测项目中使用
        /// </summary>
        public virtual ICollection<Project> Projects { get; set; }

    }
}
