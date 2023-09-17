using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw.Domain.Models.ApiResponse;
public class ApiResponse
{
    public Meta meta { get; set; } = null!;
    public dynamic response { get; set; } = null!;
}