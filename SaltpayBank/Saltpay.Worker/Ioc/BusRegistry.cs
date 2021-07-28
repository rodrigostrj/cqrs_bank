using GreenPipes;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saltpay.Worker.Consumers;
using SaltpayBank.Application.Events;
using SaltpayBank.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saltpay.Worker.Ioc
{
    public static class BusRegistry
    {
        public static void SetupBusIoc(this IServiceCollection services)
        {
            services.AddMassTransit(cc =>
            {
                cc.AddConsumers(Assembly.GetExecutingAssembly());
                cc.AddBus(context => BuildRabbitMqBus(context));
            });
        }

        private static IBusControl BuildRabbitMqBus(IBusRegistrationContext context)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var rabbitmqOptions = context.GetService<IConfiguration>().GetSection(RabbitMqOptions.RabbitMqOptionsKey).Get<RabbitMqOptions>();

                cfg.Host(new Uri(rabbitmqOptions.QueueHost), configurator =>
                {
                    configurator.Username(rabbitmqOptions.QueueUsername);
                    configurator.Password(rabbitmqOptions.QueuePassword);
                    configurator.Heartbeat(rabbitmqOptions.QueueHeartbeat);
                });

                cfg.UseConcurrencyLimit(rabbitmqOptions.ConcurrencyLimit);

                cfg.ReceiveEndpoint(
                    rabbitmqOptions.QueueName,
                    configurator =>
                    {
                        configurator.PrefetchCount = rabbitmqOptions.PrefetchCount;

                        // ######### NewAccountMessageConsumer
                        configurator.ConfigureConsumer<NewAccountMessageConsumer>(context, cf =>
                        {
                            cf.UseMessageRetry(retry =>
                            {
                                retry.Incremental(5, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
                            });

                        });
                        configurator.Consumer<NewAccountMessageConsumer>(context);

                        // ######### NewAccountTransferMessageConsume
                        configurator.ConfigureConsumer<NewAccountTransferMessageConsumer>(context, cf =>
                        {
                            cf.UseMessageRetry(retry =>
                            {
                                retry.Incremental(5, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
                            });

                        });
                        configurator.Consumer<NewAccountTransferMessageConsumer>(context);
                    });

            });
        }
    }
}
