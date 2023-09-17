using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw.Domain.Models;

public class ConfigItem
{
    public int? LINE { get; set; }
    public int NO { get; set; }
    public string LINETEXT { get; set; } = null!;
}