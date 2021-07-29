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
    public class AddNewAccountTransferCommandHandler
        : IRequestHandler<AddNewAccountTransferCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IEventPublisher _eventPublisher;
        private readonly NotificationContext _notificationContext;
        private readonly IAccountRepository _accountRepository;

        public AddNewAccountTransferCommandHandler(
            IMediator mediator, 
            IEventPublisher eventPublisher,
            NotificationContext notificationContext,
            IAccountRepository accountRepository)
        {
            _mediator = mediator;
            _eventPublisher = eventPublisher;
            _notificationContext = notificationContext;
            _accountRepository = accountRepository;
        }

        public async Task<bool> Handle(AddNewAccountTransferCommand request, CancellationToken cancellationToken)
        {
            var originAccount = _accountRepository.Get(request.AccountOriginId);
            var destinyAccount = _accountRepository.Get(request.AccountDestitnyId);

            var NewTransferToValidate = new Transfer
            {
                OriginAccount = originAccount,
                DestinyAccount = destinyAccount,
                AmountToTransfer = request.Amount
            };

            NewTransferToValidate.Validate();
            if (NewTransferToValidate.Invalid)
            {
                _notificationContext.AddNotifications(NewTransferToValidate.ValidationResult);
                return false;
            }

            await _eventPublisher.PublishAsync(
                new NewAccountTransferMessage { 
                    AccountOrigin = originAccount,
                    AccountDestitny = destinyAccount,
                    Amount = request.Amount 
                });

            return true;
        }
    }
}
