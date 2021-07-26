using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Seedwork.EventBus
{
    public interface IEventPublisher
    {
        Task PublishAsync(object message);
    }
}
