namespace ApiaryManagementSystem.Infrastructure.Data.Configurations;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Inspections;
using ApiaryManagementSystem.Infrastructure.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Constants.Models.Common;
using static Domain.Constants.Models.Inspection;

internal sealed class InspectionConfiguration : IEntityTypeConfiguration<Inspection>
{
    public void Configure(EntityTypeBuilder<Inspection> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Hive)
            .WithMany(x => x.Inspections)
            .HasForeignKey(x => x.HiveId)
            .IsRequired();

        builder.Property(x => x.InspectionDate)
            .IsRequired();

        builder.Property(x => x.ColonyStrength)
            .HasConversion(
                column => column.Name,
                column => Enumeration.FromName<ColonyStrength>(column))
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.FramesWithCappedBrood)
            .HasConversion(new FramesConverter())
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.FramesWithUncappedBrood)
            .HasConversion(new FramesConverter())
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.FramesWithHoney)
            .HasConversion(new FramesConverter())
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.FramesWithPollen)
            .HasConversion(new FramesConverter())
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.FramesWithFreeSpace)
            .HasConversion(new FramesConverter())
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.BroodPattern)
            .HasConversion(
                column => column.Name,
                column => Enumeration.FromName<BroodPattern>(column))
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.SwarmingState)
            .HasConversion(
                column => column.Name,
                column => Enumeration.FromName<SwarmingState>(column))
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.BeeBehaviour)
            .HasConversion(
                column => column.Name,
                column => Enumeration.FromName<BeeBehaviour>(column))
            .HasMaxLength(EnumerationNameMaxLength)
            .IsRequired();

        builder.Property(x => x.IsQueenPresent)
            .IsRequired();

        builder.Property(x => x.AreEggsPresent)
            .IsRequired();

        builder.Property(x => x.AreQueenCellsPresent)
            .IsRequired();

        builder.Property(x => x.AreDroneCellsPresent)
            .IsRequired();

        builder.Property(x => x.Notes)
            .HasMaxLength(NotesMaxLength)
            .IsRequired(false);
    }
}
