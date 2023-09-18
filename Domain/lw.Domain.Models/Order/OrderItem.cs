using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw.Domain.Models;
public class OrderItem
{
    public string UNITPRICE { get; set; }
    public string DESCRIPTION { get; set; }
    public string ID { get; set; }
    public string PRODUCTID { get; set; }
    public string MENUID { get; set; }
    public string REMARKBYITEM { get; set; }
    public string KITCHENREMARK { get; set; }
    public string ITEMDISC { get; set; }
    public double QTY { get; set; }
    public int SEPERATEINVOICE { get; set; }
    public int SEPERATECUSTOMERS { get; set; }
    public int COURSENB { get; set; }
    public double PRINTOUT1 { get; set; }
    public double PRINTOUT2 { get; set; }
    public double PRINTOUT3 { get; set; }
    public double PRINTOUT4 { get; set; }
    public double PRINTOUT5 { get; set; }
    public double TAX1 { get; set; }
    public double TAX2 { get; set; }
    public double TAX3 { get; set; }
    public double TTAX4 { get; set; }
    public double TTAX5 { get; set; }
}