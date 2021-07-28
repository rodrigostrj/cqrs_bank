using AutoMapper;
using MediatR;
using SaltpayBank.Application.Events;
using SaltpayBank.Application.Models;
using SaltpayBank.Seedwork.EventBus;
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
        public IMediator Mediator { get; }
        public IMapper Mapper { get; }
        public IEventPublisher EventPublisher { get; }

        public AddNewAccountTransferCommandHandler(IMediator mediator, IMapper mapper, IEventPublisher eventPublisher)
        {
            this.Mediator = mediator;
            this.Mapper = mapper;
            this.EventPublisher = eventPublisher;
        }

        public Task<bool> Handle(AddNewAccountTransferCommand request, CancellationToken cancellationToken)
        {
            EventPublisher.PublishAsync(
                new NewAccountTransferMessage { 
                    AccountOriginId = request.AccountOriginId,
                    AccountDestitnyId = request.AccountDestitnyId,
                    Amount = request.Amount 
                });

            return Task.Factory.StartNew(() => true);
        }
    }
}
