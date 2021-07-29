using AutoMapper;
using MediatR;
using SaltpayBank.Application.Events;
using SaltpayBank.Application.Models;
using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Seedwork;
using SaltpayBank.Seedwork.EventBus;
using SaltpayBank.Seedwork.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Commands
{
    public class AddNewBankAccountToCustomerCommandHandler
        : IRequestHandler<AddNewBankAccountToCustomerCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;
        private readonly NotificationContext _notificationContext;

        public AddNewBankAccountToCustomerCommandHandler(
            IMediator mediator, 
            IMapper mapper, 
            IEventPublisher eventPublisher,
            NotificationContext notificationContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Handle(AddNewBankAccountToCustomerCommand request, CancellationToken cancellationToken)
        {
            //var customer = await _repository.GetAsync(x => x.Id == request.CustomerId);
            var customer = new Customer { Id = 1, Name = "Fulano" };

            var NewAccountToValidate = new Account
            {
                Amount = request.Amount,
                Customer = customer,
            };

            NewAccountToValidate.Validate();
            if (NewAccountToValidate.Invalid)
            {
                _notificationContext.AddNotifications(NewAccountToValidate.ValidationResult);
                return false; 
            }

            await _eventPublisher.PublishAsync(
                new NewAccountMessage {
                    Amount = request.Amount, 
                    CustomerId = request.CustomerId });

            return true;
        }
    }
}
