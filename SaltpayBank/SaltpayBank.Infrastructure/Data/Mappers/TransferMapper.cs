using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaltpayBank.Domain.AccountAggregate;

namespace SaltpayBank.Infrastructure.Data.Mappers
{
    //public class TransferMapper : IEntityTypeConfiguration<Transfer>
    //{
    //    public void Configure(EntityTypeBuilder<Transfer> builder)
    //    {
    //        builder.ToTable("Transfers");
    //        builder.HasKey(t => t.Id);
    //        builder.HasOne(t => t.OriginAccount).WithOne().HasForeignKey("AccountOriginId").IsRequired(true);
    //        builder.HasOne(t => t.DestinyAccount).WithOne().HasForeignKey("AccountDestinyId").IsRequired(true);
    //        builder.Property(t => t.MoneyToTransfer.Amount).HasColumnName("Amount");
    //        builder.Property(t => t.DateTransfer).HasColumnName("DateTransfer");
    //    }
    //}
}
