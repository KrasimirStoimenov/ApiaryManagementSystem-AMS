namespace ApiaryManagementSystem.Domain.Models.Inspections;

using ApiaryManagementSystem.Domain.Common;

public sealed class ColonyStrength : Enumeration
{
    public static readonly ColonyStrength Queenless = new(0, nameof(Queenless));
    public static readonly ColonyStrength Collapsing = new(1, nameof(Collapsing));
    public static readonly ColonyStrength Nucleus = new(2, nameof(Nucleus));
    public static readonly ColonyStrength Weak = new(3, nameof(Weak));
    public static readonly ColonyStrength Moderate = new(4, nameof(Moderate));
    public static readonly ColonyStrength Strong = new(5, nameof(Strong));

    private ColonyStrength(int value, string name)
        : base(value, name)
    {
    }
}
