using AutoMapper;
using MediatR;
using SaltpayBank.Application.Events;
using SaltpayBank.Application.Models;
using SaltpayBank.Domain.AccountAggregate;
using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
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
        private readonly ICustomerRepository _customerRepository;

        public AddNewBankAccountToCustomerCommandHandler(
            IMediator mediator, 
            IMapper mapper, 
            IEventPublisher eventPublisher,
            NotificationContext notificationContext,
            ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _notificationContext = notificationContext;
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(AddNewBankAccountToCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.Get(request.CustomerId);

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
                    Customer = customer });

            return true;
        }
    }
}
