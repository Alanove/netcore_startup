using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw.Domain.Models;

public class AmountPaid
{
    [Key]
    public int id { get; set; }
    public double PAYMENTTID { get; set; }
    public double AMOUNTPAID { get; set; }
    public double AMOUNTRECEIVED { get; set; }
    public string TRANSACTIONTYPE { get; set; }
}