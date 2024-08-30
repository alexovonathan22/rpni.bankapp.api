using RpnInnovation.Application.Features.Account.DTO.Request;
using RpnInnovation.Application.Features.Account.DTO.Response;
using RpnInnovation.Application.Features.Account.Interfaces;
using RpnInnovation.Application.Features.Email;
using RpnInnovation.Application.Helper;
using RpnInnovation.Application.OtherInterfaces;
using RpnInnovation.Domain.Entities;
using RpnInnovation.Domain.Helper;

namespace RpnInnovation.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<CustomerAccount> _customerRepository;
        private readonly IReadRepository<CustomerAccount> _readCustomerRepo;
        private readonly IRepository<Account> _acctRepository;
        private readonly IReadRepository<Account> _readAcctRepository;
        private readonly IEmailService _emailService;

        public AccountService(IReadRepository<Account> readAcctRepository, IRepository<Account> acctRepository, IReadRepository<CustomerAccount> readCustomerRepo, IRepository<CustomerAccount> customerRepository, IEmailService emailService)
        {
            _readAcctRepository = readAcctRepository;
            _acctRepository = acctRepository;
            _readCustomerRepo = readCustomerRepo;
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public async Task<BaseReponse<AccountCreationResponse>> CreateBankAccount(AccountCreationRequest dto)
        {
            var response = new BaseReponse<AccountCreationResponse>();
            //create cst
            // prepared cst entity to send into db
            var cst = AccountCreationRequest.Copy(dto);
            var createCst = await _customerRepository.AddAsync(cst);

            if (createCst is null || createCst.Id < 1)
            {
                response.Message = $"Could not create customer, try again later.";
                response.Data = new AccountCreationResponse();
                return response;
            }
            //create act
            // populating account object
            var cstAccount = AccountCreationRequest.Copy(createCst, dto);
            var createAccount = await _acctRepository.AddAsync(cstAccount);

            if (createAccount is null || createAccount.Id < 1)
            {
                response.Message = $"Could not create customer-account, try again later.";
                response.Data = new AccountCreationResponse();
                return response;
            }

            // TODO :: send email
            // step 1: it to prepare our message
            var emailPayload = Generators.CreateWelcomeEmail(createCst, createAccount);
            // call our email service to send prepared-msg to cst
            var sendEmail = _emailService.SendEmailAsync(emailPayload);
            if (sendEmail)
            {
                response.Status = true;
                response.Message = $"Account created, you should receive an email confirmation.";
                response.Data = new AccountCreationResponse() { AccountNumber = createAccount.AccountNumber, AccountTypeCreated = dto.AccountType.ToString(), CreatedOn = DateTime.Now };
                return response;
            }
            response.Status = true;
            response.Message = $"Account created, but could not send email confirmation instantly.";
            response.Data = new AccountCreationResponse() { AccountNumber = createAccount.AccountNumber, AccountTypeCreated = dto.AccountType.ToString(), CreatedOn = DateTime.Now };
            return response;
        }

        public Task<BaseReponse<object>> GetAccountBalance(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<GetAccountDetailResponse>> GetBankAccountDetails(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<BaseReponse<AccountUpdateResponse>> UpdateAccountDetails(AccountUpdateRequest dto)
        {
            throw new NotImplementedException();
        }

    }
}
