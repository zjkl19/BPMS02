using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Models
{
    /// <summary>
    /// 发票
    /// </summary>
    public class Invoice
    {

        public Guid Id { get; set; }

        /// <summary>
        /// 开具日期
        /// </summary>
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 1张发票只属于1份合同
        /// </summary>
        public virtual Contract Contract { get; set; }

        /// <summary>
        /// 1张发票可以有n次到账
        /// </summary>
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
