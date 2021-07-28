using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaltpayBank.Api.ApiContracts.Requests;
using SaltpayBank.Api.ApiContracts.Responses;
using SaltpayBank.Application.Commands;
using SaltpayBank.Application.Queries;
using System;
using System.Collections.Generic;
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
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult> TransferAmount(AddNewAccountTransferRequest addNewAccountTransferRequest)
        {
            try
            {
                var command = new AddNewAccountTransferCommand(
                    addNewAccountTransferRequest.AccountOriginId,
                    addNewAccountTransferRequest.AccountDestinyId,
                    addNewAccountTransferRequest.Amount);
                var response = await _mediator.Send(command);
                return new AcceptedResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Transfer");
                throw;
            }
        }

        // - Retrieve balances for a given account.
        [HttpGet("{accountId}/balance")]
        public async Task<ActionResult<Balance>> GetBalances(int accountId)
        {
            try
            {
                var command = new GetBalanceByAccountQuery(accountId);
                var response = await _mediator.Send(command);
                var balance = _mapper.Map<Balance>(response);
                return Ok(balance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error the balance by account");
                throw;
            }
        }

        // - Retrieve transfer history for a given account.
        [HttpGet("{accountId}/transfer-history")]
        public async Task<ActionResult<List<Transfer>>> GetTransferHistoryAsync(int accountId)
        {
            try
            {
                var command = new GetTransferListByAccountQuery(accountId);
                var response = await _mediator.Send(command);
                var transferList = _mapper.Map<List<Transfer>>(response);
                return Ok(transferList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error the balance by account");
                throw;
            }
        }
    }
}
