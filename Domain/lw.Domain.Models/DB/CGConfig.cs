using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw.Domain.Models;

public class GCConfig
{
    public decimal NO { get; set; }
    public decimal LINE { get; set; }
    public decimal BRANCHID { get; set; }
    public string LINETEXT { get; set; }
    public DateTime CDATE { get; set; }
    public string DESCRIPTION { get; set; }
    public string MODULE { get; set; }
    public string MODULE_PART { get; set; }
    public decimal SORTBY { get; set; }
    public decimal TYPES { get; set; }
    public decimal VALUEFROM { get; set; }
}