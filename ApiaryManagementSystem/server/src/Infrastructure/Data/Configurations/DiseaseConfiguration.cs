namespace ApiaryManagementSystem.Infrastructure.Data.Configurations;

using ApiaryManagementSystem.Domain.Models.Diseases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Constants.Models.Common;
using static Domain.Constants.Models.Disease;

internal sealed class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Hive)
            .WithMany(x => x.Diseases)
            .HasForeignKey(x => x.HiveId)
            .IsRequired();

        builder
            .Property(x => x.Name)
            .HasMaxLength(NameMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Treatment)
            .HasMaxLength(TreatmentMaxLength)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasMaxLength(DescriptionMaxLength)
            .IsRequired(false);
    }
}
