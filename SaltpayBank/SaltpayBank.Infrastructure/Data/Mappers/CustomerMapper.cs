using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaltpayBank.Domain.AccountAggregate;

namespace SaltpayBank.Infrastructure.Data.Mappers
{
    public class CustomerMapper : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.HasMany(c => c.AccountList).WithOne(c => c.Customer);
        }
    }
}
