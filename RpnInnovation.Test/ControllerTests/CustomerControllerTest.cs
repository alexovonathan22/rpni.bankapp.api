using Microsoft.AspNetCore.Mvc;
using Moq;
using RpnInnovation.Application.Features.Account.DTO.Request;
using RpnInnovation.Application.Features.Account.Interfaces;
using RpnInnovation.Domain.Enums;
using RpnInnovation.WebApi.Controllers;

namespace RpnInnovation.Test.ControllerTests
{
    public class CustomerControllerTest
    {
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly CustomerController _controller;
        public CustomerControllerTest()
        {
            _mockAccountService = new Mock<IAccountService>();
            _controller = new CustomerController(_mockAccountService.Object);
        }

        [Fact]
        public async Task CreateAccount_ShouldCreateAccount_Successful()
        {
            var acctREq = AccountCreationRequest.CopyTestsPayloadOK();
            var result = await _controller.CreateAccount(acctREq);

            Assert.NotNull(acctREq);
            Assert.NotNull(acctREq.FirstName);
            Assert.NotNull(acctREq.LastName);

            Assert.IsType<AccountType>(acctREq.AccountType);
        }

        [Fact]
        public async Task CreateAccount_ShouldFail_To_CreateAccount_Fail()
        {
            var acctREq = AccountCreationRequest.CopyTestsPayloadFailed();
            var result = await _controller.CreateAccount(acctREq);

            Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsNotType<OkObjectResult>(result);
        }
    }
}
