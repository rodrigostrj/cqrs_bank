using MassTransit;
using SaltpayBank.Application.Events;
using SaltpayBank.Domain.AccountAggregate;
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

        public NewAccountTransferMessageConsumer()
        {
        }

        public async Task Consume(ConsumeContext<NewAccountTransferMessage> context)
        {
            //var repository = _unitOfWork.AsyncRepository<Transfer>();
            //await repository.AddAsync(new Transfer { });
            // Update Account and Transfer
            //await _unitOfWork.SaveChangesAsync();
        }
    }
}
