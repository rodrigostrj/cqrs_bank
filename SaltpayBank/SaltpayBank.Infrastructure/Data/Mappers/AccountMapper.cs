using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaltpayBank.Domain.AccountAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Infrastructure.Data.Mappers
{
    public class AccountMapper : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Customer);
            builder.Property(a => a.Amount).IsRequired();
        }
    }
}
