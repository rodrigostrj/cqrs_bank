using MassTransit;
using SaltpayBank.Seedwork.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Infrastructure.EventBus
{
    public class EventPublisher : IEventPublisher
    {
        private IBus _bus;

        public EventPublisher(IBus bus)
        {
            this._bus = bus;
        }

        public async Task PublishAsync(object message)
        {
            var uri = new Uri("rabbitmq://localhost/saltpaybank_processor_local");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(message);
        }
    }
}
