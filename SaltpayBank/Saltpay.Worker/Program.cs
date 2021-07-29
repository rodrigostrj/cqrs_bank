using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saltpay.Worker.Ioc;
using SaltpayBank.Domain.AccountAggregate.RepositoryContracts;
using SaltpayBank.Domain.AccountAggregate.Services;
using SaltpayBank.Infrastructure.Data;
using SaltpayBank.Infrastructure.Data.Repositories;
using SaltpayBank.Infrastructure.EventBus;
using SaltpayBank.Seedwork;
using SaltpayBank.Seedwork.Repository;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace Saltpay.Worker
{
    public class Program
    {
        private static IConfigurationRoot Configuration;

        public static int Main(string[] args)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var contentRoot = Path.GetDirectoryName(path);

            try
            {
                CreateHostBuilder(contentRoot, args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string contentRoot, string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(config =>
            {
                var tokensBuilder = new ConfigurationBuilder()
                    .SetBasePath(contentRoot)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();

                 Configuration = tokensBuilder.Build();
            })
            .ConfigureServices((hostContext, services) =>
            {
                // Repositories
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddSingleton<DbSession>(s => new DbSession(Configuration.GetSection("ConnectionStrings:SaltpayBankConnectionString").Value));
                services.AddScoped<IAccountRepository, AccountRepository>();
                services.AddScoped<ICustomerRepository, CustomerRepository>();
                services.AddScoped<ITransferRepository, TransferRepository>();

                services.AddScoped<IAccountService, AccountService>();
                services.AddScoped<ITransferService, TransferService>();

                services.SetupBusIoc();

                services.AddHostedService<Worker>();
            })
            .UseWindowsService();
    }
}
