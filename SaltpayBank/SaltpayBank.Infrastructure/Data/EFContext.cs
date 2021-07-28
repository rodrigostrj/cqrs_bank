using Microsoft.EntityFrameworkCore;
using SaltpayBank.Domain.AccountAggregate;
using System;
using System.Data.Common;

namespace SaltpayBank.Infrastructure.Data
{
    public class EFContext : DbContext
    {
        public EFContext()
        {

        }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);

            //CreateInitialData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=saltpaybank_db_app;User Id=sa;Password=1p@sswordY;");
            }
        }

        private static void CreateInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                    new Customer { Id = 1, Name = "Arisha Barron" },
                    new Customer { Id = 2, Name = "Branden Gibson" },
                    new Customer { Id = 3, Name = "Rhonda Church" },
                    new Customer { Id = 4, Name = "Georgina Hazel" }
                );
        }
    }
}
