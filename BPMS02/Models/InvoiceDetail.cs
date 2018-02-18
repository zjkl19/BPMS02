using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Models
{
    /// <summary>
    /// 发票明细
    /// </summary>
    public class InvoiceDetail
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 到账金额
        /// </summary>
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 1个发票到账明细只属于1个合同
        /// </summary>
        public virtual Invoice Invoice { get; set; }
    }
}
