using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaltpayBank.Api.ApiContracts.Requests;
using SaltpayBank.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaltpayBank.Api.Controllers
{
    [ApiController]
    [Route("/api/saltpaybank/[controller]")]
    public class SaltPayController : ControllerBase
    {

        private readonly ILogger<SaltPayController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SaltPayController(IMediator mediator, IMapper mapper, ILogger<SaltPayController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        // - Create a new bank account for a customer, with an initial deposit amount. 
        //   A single customer may have multiple bank accounts.
        [HttpPost("{customerId}/account")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult> CreateAccount(AddNewBankAccountToCustomerRequest addNewBankAccountRequest, int customerId)
        {
            try
            {
                var command = new AddNewBankAccountToCustomerCommand(customerId, addNewBankAccountRequest.Amount);
                var response = await _mediator.Send(command);
                return new AcceptedResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating account");
                throw;
            }
        }

        // - Transfer amounts between any two accounts, including those owned by different customers.
        [HttpPost("{accountId}/transfer")]
        public IActionResult TransferAmount(object transfer)
        {
            try
            {
                throw new NotFiniteNumberException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating transfer");
                throw ex;
            }
        }

        // - Retrieve balances for a given account.
        [HttpGet("{accountId}/balance")]
        public IEnumerable<object> GetBalances(Guid accountId)
        {
            try
            {
                throw new NotFiniteNumberException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting ballence by account");
                throw ex;
            }
        }


        // - Retrieve transfer history for a given account.
        [HttpGet("{accountId}/transfer-history")]
        public IEnumerable<object> GetTransferHistory()
        {
            try
            {
                throw new NotFiniteNumberException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting transfer history by account");
                throw ex;
            }
        }
    }
}
