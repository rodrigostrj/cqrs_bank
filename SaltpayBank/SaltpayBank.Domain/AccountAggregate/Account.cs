using FluentValidation;
using SaltpayBank.Domain.AccountAggregate.ValueObjects;
using SaltpayBank.Seedwork;
using System;
using System.Collections.Generic;

namespace SaltpayBank.Domain.AccountAggregate
{
    public class Account : BaseEntity
    {
        public override void Validate()
        {
            Validate(this, new AccountValidator());
        }
        public decimal Amount { get; set; }
        public Customer Customer { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var a = (Account)obj;
                return a.Id == this.Id;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Amount);
        }
    }

    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(a => a.Amount).GreaterThan(0)
                .WithMessage("amount values must be greather then 0");

            RuleFor(a => a.Customer)
                .NotNull().WithMessage("A cusmomer is needed");
        }
    }
}