using RpnInnovation.Application.Features.Account.DTO.Request;
using RpnInnovation.Application.Features.Account.DTO.Response;
using RpnInnovation.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Application.Features.Account.Interfaces
{
    public interface IAccountService
    {
        Task<BaseReponse<CustomerCreationResponse>> CreateBankAccount(CustomerCreationRequest dto);
        Task<BaseReponse<CustomerUpdateResponse>> UpdateAccountDetails(CustomerUpdateRequest dto);
        Task<BaseReponse<GetAccountDetailResponse>> GetBankAccountDetails(string accountNumber);
        Task<BaseReponse<object>> GetAccountBalance(string accountNumber);

    }
}
