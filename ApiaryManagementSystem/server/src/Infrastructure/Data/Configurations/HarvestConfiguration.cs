namespace ApiaryManagementSystem.Infrastructure.Data.Configurations;

using ApiaryManagementSystem.Domain.Models.Harvests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Constants.Models.Harvest;

internal sealed class HarvestConfiguration : IEntityTypeConfiguration<Harvest>
{
    public void Configure(EntityTypeBuilder<Harvest> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Hive)
            .WithMany(x => x.Harvests)
            .HasForeignKey(x => x.HiveId)
            .IsRequired();

        builder
            .Property(x => x.Date)
            .IsRequired();

        builder
            .Property(x => x.Amount)
            .HasPrecision(9, 2)
            .IsRequired();

        builder
            .Property(x => x.Product)
            .HasMaxLength(HarvestedProductMaxLength)
            .IsRequired();
    }
}
