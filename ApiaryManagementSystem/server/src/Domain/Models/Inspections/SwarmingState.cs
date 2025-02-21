namespace ApiaryManagementSystem.Domain.Models.Inspections;

using ApiaryManagementSystem.Domain.Common;

public sealed class SwarmingState : Enumeration
{
    public static readonly SwarmingState PreSwarming = new(0, nameof(PreSwarming));
    public static readonly SwarmingState SwarmingPreparation = new(1, nameof(SwarmingPreparation));
    public static readonly SwarmingState PrimarySwarm = new(2, nameof(PrimarySwarm));
    public static readonly SwarmingState PostSwarm = new(3, nameof(PostSwarm));

    private SwarmingState(int value, string name)
        : base(value, name)
    {
    }
}
