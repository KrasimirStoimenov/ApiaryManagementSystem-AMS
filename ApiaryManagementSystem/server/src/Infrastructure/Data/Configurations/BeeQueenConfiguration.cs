namespace ApiaryManagementSystem.Infrastructure.Data.Configurations;

using ApiaryManagementSystem.Domain.Models.BeeQueens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static ApiaryManagementSystem.Domain.Constants.Models.BeeQueen;

internal sealed class BeeQueenConfiguration : IEntityTypeConfiguration<BeeQueen>
{
    public void Configure(EntityTypeBuilder<BeeQueen> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Hive)
            .WithMany(x => x.BeeQueens)
            .HasForeignKey(x => x.HiveId)
            .IsRequired();

        builder
            .Property(x => x.Year)
            .IsRequired();

        builder
            .Property(x => x.ColorMark)
            .HasMaxLength(ColorMarkMaxLength)
            .IsRequired(false);

        builder
            .Property(x => x.IsAlive)
            .IsRequired();
    }
}
