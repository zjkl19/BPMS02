using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPMS02.Areas.Dev.Models
{
    public class BridgeQuery
    {
        [Display(Name = "桥梁名称")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
