using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw.Domain.Models;

public class OrderRequest : BaseRequest
{
    [Key]
    public int id { get; set; }
    public string type { get; set; }
    public int workstationid { get; set; }
    public int modeid { get; set; }
    public int status { get; set; }
    public int offlineinvoice { get; set; }
    public int realinvoicenumb { get; set; }
    public int menuid { get; set; }
    public int customer_nbr { get; set; }
    public int invoice_nbr { get; set; }
    public int iseuropean { get; set; }
    public string current_time { get; set; }
    public int customerid { get; set; }
    public string customername { get; set; }
    public string remchar { get; set; }
    public string tax1 { get; set; }
    public string tax2 { get; set; }
    public string tax3 { get; set; }
    public string tax4 { get; set; }
    public string tax5 { get; set; }
    public string discount { get; set; }
    public string amount { get; set; }
    public string service { get; set; }
    public List<OrderItem> items { get; set; }
    public List<AmountPaid> amountpaid { get; set; }
    public int salesmenid { get; set; }
}
