using Microsoft.AspNetCore.Mvc;
using RpnInnovation.Application.Features.Account.DTO.Request;
using RpnInnovation.Application.Features.Account.Interfaces;

namespace RpnInnovation.WebApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public CustomerController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount(AccountCreationRequest dto)
        {
            // todo :: log input

            var serviceResponse = await _accountService.CreateBankAccount(dto);
            // todo :: log output
            if (serviceResponse is not null) {
                return Ok(serviceResponse);
            }
            return BadRequest(serviceResponse);
        }
    }
}
