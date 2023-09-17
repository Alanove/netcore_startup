using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw.Domain.Models;

public class OrderResponseItem
{
    
    public int invoice_nbr { get; set; }
    public int counter { get; set; }
    public string tablenumber { get; set; }
}