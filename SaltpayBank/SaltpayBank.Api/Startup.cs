using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SaltpayBank.Application.Commands;
using SaltpayBank.Infrastructure.Data;
using SaltpayBank.Infrastructure.Data.Repositories;
using SaltpayBank.Seedwork;
using MediatR;
using SaltpayBank.Api.Mappers;
using SaltpayBank.Application.Mappers;
using MassTransit;
using SaltpayBank.Infrastructure.EventBus;
using System;
using GreenPipes;
using SaltpayBank.Seedwork.EventBus;
using SaltpayBank.Domain.AccountAggregate.Services;
using SaltpayBank.Seedwork.Notifications;
using SaltpayBank.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using SaltpayBank.Seedwork.Repository;
using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
using SaltpayBank.Api.DB_DataInitializaer;

namespace SaltpayBank.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // TODO: Improve DI

            services.AddMassTransit(cc =>
            {
                cc.AddBus(context => BuildRabbitMqBus(context));
            });
            services.AddMassTransitHostedService();
            //EventPublisher
            services
                .AddSingleton<IEventPublisher, EventPublisher>();


            // Domains Services 
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransferService, TransferService>();

            // Event Handlers
            services.AddMediatR(cfg => { }, typeof(AddNewBankAccountToCustomerCommandHandler).Assembly);
            services.AddScoped<NotificationContext>();

            // Sample Data 
            services.AddTransient<SampleDataHelper>();

            // Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<DbSession>(s => new DbSession(Configuration.GetSection("ConnectionStrings:SaltpayBankConnectionString").Value));
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransferRepository, TransferRepository>();

            services.AddAutoMapper(typeof(ApiProfile), typeof(ApplicationProfile));
            // #############################################################

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaltpayBank.Api", Version = "v1" });
            });

            services.AddMvc(options => options.Filters.Add<NotificationFilter>())
                    .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaltpayBank.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
            });
        }
    }
}
