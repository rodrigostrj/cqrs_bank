using AutoMapper;
using MediatR;
using SaltpayBank.Application.Models;
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
        public IMediator Mediator { get; }
        public IMapper Mapper { get; }

        public AddNewBankAccountToCustomerCommandHandler(IMediator mediator, IMapper mapper)
        {
            this.Mediator = mediator;
            this.Mapper = mapper;

        }

        public Task<bool> Handle(AddNewBankAccountToCustomerCommand request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(()=> true);
        }
    }
}
