using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lw.Domain.Models;

public class BaseRequest
{
    [JsonPropertyName("omega_customerid")]
    public string OmegaCustomerId { get; set; } = null!;
    [JsonPropertyName("x-session")]
    public string XSession { get; set; } = null!;
}
