using MediatR;
using SaltpayBank.Application.Models;
using SaltpayBank.Domain.AccountAggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Queries
{
    public class GetBalanceByAccountQueryHandler : IRequestHandler<GetBalanceByAccountQuery, AccountDTO>
    {
        private IAccountService _accountService;

        public GetBalanceByAccountQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public Task<AccountDTO> Handle(GetBalanceByAccountQuery request, CancellationToken cancellationToken)
        {
            var account = _accountService.GetAccount(request.AccountId);
            return Task.Factory.StartNew(
                () => new AccountDTO {
                    Amount = account.Amount,
                    Id = account.Id
                });
        }
    }
}
