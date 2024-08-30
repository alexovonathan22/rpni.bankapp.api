using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Domain.AppSettings
{
    public class EmailSettings
    {
        public string? Sender { get; set; }
        public string? Password { get; set; }
        public int SmptPort { get; set; }
        public string? SmptServer { get; set; }
    }
}
