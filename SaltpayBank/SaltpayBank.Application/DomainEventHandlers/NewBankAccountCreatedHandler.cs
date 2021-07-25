using MediatR;
using Microsoft.Extensions.Logging;
using SaltpayBank.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaltpayBank.Application.DomainEventHandlers
{
    public class NewBankAccountCreatedHandler : INotificationHandler<AccountCreated>
    {
        private readonly ILogger<NewBankAccountCreatedHandler> _logger;

        public NewBankAccountCreatedHandler(ILogger<NewBankAccountCreatedHandler> logger)
        {
            this._logger = logger;
        }

        public Task Handle(AccountCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Domain Event [AccountCreated]: Account: {notification.Account.Id}.");
            return Task.CompletedTask;
        }
    }
}
