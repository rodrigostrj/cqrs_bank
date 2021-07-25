using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaltpayBank.Seedwork
{
    public interface IDomainEvent : INotification
    {
    }
}
