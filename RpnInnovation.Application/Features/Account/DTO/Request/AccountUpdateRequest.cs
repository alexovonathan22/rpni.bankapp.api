﻿using RpnInnovation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Application.Features.Account.DTO.Request
{
    public class AccountUpdateRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Phone { get; set; }
        public AccountType? AccountType { get; set; }
    }
}
