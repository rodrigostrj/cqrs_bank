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
    public class GetTransferListByAccountQueryHandler : IRequestHandler<GetTransferListByAccountQuery, List<TransferDTO>>
    {
        public GetTransferListByAccountQueryHandler()
        {

        }

        public Task<List<TransferDTO>> Handle(GetTransferListByAccountQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
