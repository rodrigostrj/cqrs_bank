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
        private ICustomerRepository _customerRepository;

        public NewAccountMessageConsumer(
            IAccountService accountService,
            ICustomerRepository customerRepository)
        {
            _accountService = accountService;
            _customerRepository = customerRepository;
        }

        public async Task Consume(ConsumeContext<NewAccountMessage> context)
        {
            var customer = _customerRepository.Get(context.Message.Customer.Id);
            var account = new Account
            {
                Customer = customer,
                Amount = context.Message.Amount
            };

            _accountService.CreateBankAccount(account);
        }
    }
}
