using FluentValidation;
using SaltpayBank.Domain.AccountAggregate.ValueObjects;
using SaltpayBank.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate
{
    public class Transfer : BaseEntity
    {
        public Account OriginAccount { get; set; }
        public Account DestinyAccount { get; set; }
        public decimal AmountToTransfer { get; set; }
        public decimal OriginAccountAmountBeforeTransfer { get; set; }
        public DateTime DateTransfer { get; set; }

        public override void Validate()
        {
            Validate(this, new TransferValidator());
        }

        public class TransferValidator : AbstractValidator<Transfer>
        {
            public TransferValidator()
            {
                RuleFor(a => a.DestinyAccount)
                    .NotNull()
                    .WithMessage("Invalid Destiny Account");

                RuleFor(a => a.DestinyAccount)
                    .NotNull()
                    .WithMessage("Invalid Origin Account");

                RuleFor(a => a.OriginAccount).NotEqual(a => a.DestinyAccount)
                    .WithMessage("Accounts must be different");

                RuleFor(a => a.AmountToTransfer)
                    .GreaterThan(0)
                    .WithMessage("Amount Value must be greater than 0");
            }
        }
    }
}
