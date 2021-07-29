using MassTransit;
using SaltpayBank.Application.Events;
using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Infrastructure.Data;
using SaltpayBank.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltpay.Worker.Consumers
{
    public class NewAccountMessageConsumer : IConsumer<NewAccountMessage>
    {

        public NewAccountMessageConsumer()
        {
        }

        public async Task Consume(ConsumeContext<NewAccountMessage> context)
        {
            //var repository = _unitOfWork.AsyncRepository<Account>();
            //await repository.AddAsync(new Account { });
            //await _unitOfWork.SaveChangesAsync();
        }
    }
}
