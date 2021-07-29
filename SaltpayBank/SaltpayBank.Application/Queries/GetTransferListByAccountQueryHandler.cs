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
    public class GetTransferListByAccountQueryHandler : IRequestHandler<GetTransferListByAccountQuery, List<TransferDTO>>
    {
        private ITransferService _transferService;

        public GetTransferListByAccountQueryHandler(ITransferService transferService)
        {
            _transferService = transferService;
        }

        public Task<List<TransferDTO>> Handle(GetTransferListByAccountQuery request, CancellationToken cancellationToken)
        {
            var transferHistory = _transferService.GetTransfers(request.AccountId);
            var transferList = new List<TransferDTO>();
            foreach (var item in transferHistory)
            {
                transferList.Add(
                    new TransferDTO {
                        TransferDate = item.DateTransfer,
                        AmountBeforeTransfer = item.OriginAccountAmountBeforeTransfer,
                        TransferAmount = item.AmountToTransfer }
                    );
            }

            return Task.Factory.StartNew(()=> transferList);
        }
    }
}
