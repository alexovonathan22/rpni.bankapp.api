﻿using RpnInnovation.Domain.Entities;
using RpnInnovation.Domain.Enums;
using RpnInnovation.Domain.Helper;
using CreateBankAccount = RpnInnovation.Domain.Entities.Account;

namespace RpnInnovation.Application.Features.Account.DTO.Request
{
    // todo :: rename class name to AccountCreationRequest CustomerCreationRequest
    public class AccountCreationRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? CountryCode { get; set; }
        public string? Phone { get; set; } 
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Bvn { get; set; }
        public AccountType AccountType { get; set; }

        public static CustomerAccount Copy(AccountCreationRequest dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var cst = new CustomerAccount
            {
                Email = dto.Email,
                Bvn = dto.Bvn,
                Country = dto.Country,
                CountryCode = dto.CountryCode,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone,
                State = dto.State,
            };
          
            return cst;
        }

        public static CreateBankAccount Copy(CustomerAccount createCst, AccountCreationRequest dto)
        {
            if (createCst == null) throw new ArgumentNullException(nameof(createCst));
           
            var cstAccount = new CreateBankAccount
            {
                Email = createCst.Email,
                AccountType = dto.AccountType,
                Bvn = createCst.Bvn,
                CustomerID = createCst.Id,
                AccountNumber = Generators.GenerateAccountNumber()
            };
            return cstAccount;
        }

        public static AccountCreationRequest CopyTestsPayloadOK()
        {
            var acctREq = new AccountCreationRequest
            {
                Email = "aov.nathan@gmail.com",
                AccountType = Domain.Enums.AccountType.Savings,
                Bvn = "2222222222",
                Country = "NG",
                CountryCode="234",
                FirstName="Aeon",
                LastName="Uyi",
                Phone="09033333333",
                State="Uyo"
            };
            return acctREq;
        }

        public static AccountCreationRequest CopyTestsPayloadFailed()
        {
            var acctREq = new AccountCreationRequest
            {
              
                AccountType = Domain.Enums.AccountType.Savings,
                Bvn = "2222222222",
                Country = "NG",
                CountryCode = "234",
                FirstName = "Aeon",
                LastName = "Uyi",
                Phone = "09033333333",
                State = "Uyo"
            };
            return acctREq;
        }
    }
}
