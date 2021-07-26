using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Infrastructure.EventBus
{
    public class RabbitMqOptions
    {
        public static string RabbitMqOptionsKey => "Rabbitmq";

        public string QueueHost { get; set; }

        public string QueueUsername { get; set; }

        public string QueuePassword { get; set; }

        public string QueueName { get; set; }

        public ushort QueueHeartbeat { get; set; }

        public int ConcurrencyLimit { get; set; }

        public ushort PrefetchCount { get; set; }
    }
}
