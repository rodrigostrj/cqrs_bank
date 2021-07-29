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
    public class AddNewAccountTransferCommandHandler
        : IRequestHandler<AddNewAccountTransferCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IEventPublisher _eventPublisher;
        private readonly NotificationContext _notificationContext;


        public AddNewAccountTransferCommandHandler(
            IMediator mediator, 
            IEventPublisher eventPublisher,
            NotificationContext notificationContext)
        {
            _mediator = mediator;
            _eventPublisher = eventPublisher;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Handle(AddNewAccountTransferCommand request, CancellationToken cancellationToken)
        {
            var originAccount = new Account { }; //= await _repository.GetAsync(x => x.Id == request.AccountOriginId);
            var destinyAccount = new Account { };  //= await _repository.GetAsync(x => x.Id == request.AccountDestitnyId);

            var NewTransferToValidate = new Transfer
            {
                OriginAccount = originAccount,
                DestinyAccount = destinyAccount,
                DateTransfer = DateTime.Now,
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
                    AccountOriginId = request.AccountOriginId,
                    AccountDestitnyId = request.AccountDestitnyId,
                    Amount = request.Amount 
                });

            return true;
        }
    }
}
