using MediatR;
using SaltpayBank.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Queries
{
    public class GetBalanceByAccountQuery : IRequest<AccountDTO>
    {
        public int AccountId { get; }

        public GetBalanceByAccountQuery(int accountId)
        {
            this.AccountId = accountId;
        }
    }
}
