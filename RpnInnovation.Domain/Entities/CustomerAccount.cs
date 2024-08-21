using RpnInnovation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Domain.Entities
{
    public class CustomerAccount : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? Bvn { get; set; }
        public string? AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
    }
}
