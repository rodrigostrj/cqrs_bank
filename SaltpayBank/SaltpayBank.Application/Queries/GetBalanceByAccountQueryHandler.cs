using MediatR;
using SaltpayBank.Application.Models;
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
        public GetBalanceByAccountQueryHandler()
        {

        }

        public Task<AccountDTO> Handle(GetBalanceByAccountQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
