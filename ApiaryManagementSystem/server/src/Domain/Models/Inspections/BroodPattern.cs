namespace ApiaryManagementSystem.Domain.Models.Inspections;

using ApiaryManagementSystem.Domain.Common;

public sealed class BroodPattern : Enumeration
{
    public static readonly BroodPattern Solid = new(0, nameof(Solid));
    public static readonly BroodPattern Spotty = new(1, nameof(Spotty));
    public static readonly BroodPattern Rainbow = new(2, nameof(Rainbow));
    public static readonly BroodPattern Drone = new(3, nameof(Drone));
    public static readonly BroodPattern Checkerboard = new(4, nameof(Checkerboard));
    public static readonly BroodPattern Patchy = new(5, nameof(Patchy));
    public static readonly BroodPattern Shotgun = new(6, nameof(Shotgun));

    private BroodPattern(int value, string name)
        : base(value, name)
    {
    }
}
