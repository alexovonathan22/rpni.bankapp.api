using RpnInnovation.Application.Features.Account.DTO.Request;
using RpnInnovation.Application.Features.Account.DTO.Response;
using RpnInnovation.Application.Features.Account.Interfaces;
using RpnInnovation.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        public AccountService()
        {
            
        }
        public Task<CustomerCreationResponse> CreateBankAccount(CustomerCreationRequest dto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<object>> GetAccountBalance(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<GetAccountDetailResponse>> GetBankAccountDetails(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<CustomerUpdateResponse>> UpdateAccountDetails(CustomerUpdateRequest dto)
        {
            throw new NotImplementedException();
        }

        Task<BaseReponse<CustomerCreationResponse>> IAccountService.CreateBankAccount(CustomerCreationRequest dto)
        {
            throw new NotImplementedException();
        }
    }
}
