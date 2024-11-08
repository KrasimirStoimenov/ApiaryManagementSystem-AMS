namespace ApiaryManagementSystem.Infrastructure.Data.Configurations;

using ApiaryManagementSystem.Domain.Models.Hives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static ApiaryManagementSystem.Domain.Constants.Models.Hive;

internal sealed class HiveConfiguration : IEntityTypeConfiguration<Hive>
{
    public void Configure(EntityTypeBuilder<Hive> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
            .HasMaxLength(NumberMaxLength)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasMaxLength(TypeMaxLength)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasMaxLength(StatusMaxLength)
            .IsRequired();

        builder.Property(x => x.Color)
            .HasMaxLength(ColorMaxLength)
            .IsRequired(false);

        builder.Property(x => x.DateBought)
            .IsRequired();

        builder
            .HasOne(x => x.Apiary)
            .WithMany(x => x.Hives)
            .HasForeignKey(x => x.ApiaryId)
            .IsRequired();
    }
}
