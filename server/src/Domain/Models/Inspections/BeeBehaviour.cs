namespace ApiaryManagementSystem.Domain.Models.Inspections;

using ApiaryManagementSystem.Domain.Common;

public sealed class BeeBehaviour : Enumeration
{
    public static readonly BeeBehaviour Calm = new(0, nameof(Calm));
    public static readonly BeeBehaviour Aggressive = new(1, nameof(Aggressive));

    private BeeBehaviour(int value, string name)
        : base(value, name)
    {
    }
}
