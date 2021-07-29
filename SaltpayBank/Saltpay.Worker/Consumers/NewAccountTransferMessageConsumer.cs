using MassTransit;
using SaltpayBank.Application.Events;
using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Domain.AccountAggregate.Services;
using SaltpayBank.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltpay.Worker.Consumers
{
    public class NewAccountTransferMessageConsumer : IConsumer<NewAccountTransferMessage>
    {
        private ITransferService _transferService;
        private IAccountService _accountService;

        public NewAccountTransferMessageConsumer(
            ITransferService transferService,
            IAccountService accountService)
        {
            _transferService = transferService;
            _accountService = accountService;
        }

        public async Task Consume(ConsumeContext<NewAccountTransferMessage> context)
        {
            var transfer = new Transfer
            {
                AmountToTransfer = context.Message.Amount,
                OriginAccount = context.Message.AccountOrigin,
                DestinyAccount = context.Message.AccountDestitny
            };

            _transferService.AccountAmountTransfer(transfer);
        }
    }
}
