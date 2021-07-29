using MassTransit;
using SaltpayBank.Application.Events;
using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
using SaltpayBank.Domain.AccountAggregate.Services;
using System.Threading.Tasks;

namespace Saltpay.Worker.Consumers
{
    public class NewAccountMessageConsumer : IConsumer<NewAccountMessage>
    {
        private IAccountService _accountService;

        public NewAccountMessageConsumer(
            IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task Consume(ConsumeContext<NewAccountMessage> context)
        {
            var account = new Account
            {
                Customer = context.Message.Customer,
                Amount = context.Message.Amount
            };

            _accountService.CreateBankAccount(account);
        }
    }
}
