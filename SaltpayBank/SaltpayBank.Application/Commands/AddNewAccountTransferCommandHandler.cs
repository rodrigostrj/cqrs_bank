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
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAsyncRepository<Account> _repository;

        public AddNewAccountTransferCommandHandler(
            IMediator mediator, 
            IMapper mapper, 
            IEventPublisher eventPublisher,
            NotificationContext notificationContext,
            IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.AsyncRepository<Account>();
        }

        public async Task<bool> Handle(AddNewAccountTransferCommand request, CancellationToken cancellationToken)
        {
            var originAccount = await _repository.GetAsync(x => x.Id == request.AccountOriginId);
            var destinyAccount = await _repository.GetAsync(x => x.Id == request.AccountDestitnyId);

            var NewTransferToValidate = new Transfer
            {
                OriginAccount = originAccount,
                DestinyAccount = destinyAccount,
                DateTransfer = DateTime.Now,
                AmountToTransfer = request.Amount
            };

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
