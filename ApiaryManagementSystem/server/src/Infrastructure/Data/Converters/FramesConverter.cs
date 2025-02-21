namespace ApiaryManagementSystem.Infrastructure.Data.Converters;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Inspections;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

internal sealed class FramesConverter : ValueConverter<Frames, string>
{
    public FramesConverter() : base(
        column => column.Name,
        column => Enumeration.FromName<Frames>(column))
    { }
}
