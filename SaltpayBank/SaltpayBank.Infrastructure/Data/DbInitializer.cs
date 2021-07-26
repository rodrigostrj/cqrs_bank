using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SaltpayBank.Domain.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(EFContext context, IServiceProvider services)
        {
            var logger = services.GetRequiredService<ILogger<DbInitializer>>();

            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                logger.LogInformation("The database was already seeded");
                return;
            }

            logger.LogInformation("Start seeding the database.");

            context.Customers.AddRange(
                    new Customer { Id = 1, Name = "Arisha Barron" },
                    new Customer { Id = 2, Name = "Branden Gibson" },
                    new Customer { Id = 3, Name = "Rhonda Church" },
                    new Customer { Id = 4, Name = "Georgina Hazel" });
            context.SaveChanges();

            logger.LogInformation("Finished seeding the database.");
        }
    }
}
