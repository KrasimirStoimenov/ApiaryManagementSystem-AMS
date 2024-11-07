namespace ApiaryManagementSystem.Domain.Models.Apiaries;

using ApiaryManagementSystem.Domain.Common;

public sealed class Apiary : BaseAuditableEntity<Guid>
{
    public Apiary(string name, string location)
    {
        this.Name = name;
        this.Location = location;
    }

    public string Name { get; private set; }

    public string Location { get; private set; }

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
