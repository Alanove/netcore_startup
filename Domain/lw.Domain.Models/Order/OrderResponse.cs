using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw.Domain.Models;
public class OrderResponse
{
    public Meta meta { get; set; } = null!;
    public OrderResponseItem response { get; set; } = null!;
}