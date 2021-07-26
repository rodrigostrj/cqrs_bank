using Microsoft.EntityFrameworkCore;
using SaltpayBank.Domain.AccountAggregate;
using System.Data.Common;

namespace SaltpayBank.Infrastructure.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
