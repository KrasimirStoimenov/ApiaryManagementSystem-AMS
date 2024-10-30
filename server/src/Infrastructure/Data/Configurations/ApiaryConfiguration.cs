namespace ApiaryManagementSystem.Infrastructure.Data.Configurations;

using ApiaryManagementSystem.Domain.Models.Apiaries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static ApiaryManagementSystem.Domain.Constants.Models.Apiary;
using static ApiaryManagementSystem.Domain.Constants.Models.Common;

internal sealed class ApiaryConfiguration : IEntityTypeConfiguration<Apiary>
{
    public void Configure(EntityTypeBuilder<Apiary> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(NameMaxLength)
            .IsRequired();

        builder.Property(x => x.Location)
            .HasMaxLength(LocationMaxLength)
            .IsRequired();
    }
}
