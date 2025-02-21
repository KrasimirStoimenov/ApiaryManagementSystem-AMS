namespace ApiaryManagementSystem.Domain.Models.Apiaries;

using ApiaryManagementSystem.Domain.Common;
using ApiaryManagementSystem.Domain.Models.Hives;

public sealed class Apiary(string name, string location) : BaseAuditableEntity
{
    public string Name { get; private set; } = name;

    public string Location { get; private set; } = location;

    public IReadOnlyCollection<Hive> Hives { get; init; } = [];

    public Apiary UpdateName(string name)
    {
        this.Name = name;

        return this;
    }

    public Apiary UpdateLocation(string location)
    {
        this.Location = location;

        return this;
    }
}
