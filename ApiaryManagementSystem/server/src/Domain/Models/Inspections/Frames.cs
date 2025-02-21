namespace ApiaryManagementSystem.Domain.Models.Inspections;

using ApiaryManagementSystem.Domain.Common;

public sealed class Frames : Enumeration
{
    public static readonly Frames None = new(0, nameof(None));
    public static readonly Frames One = new(1, nameof(One));
    public static readonly Frames Few = new(2, nameof(Few));
    public static readonly Frames Several = new(3, nameof(Several));
    public static readonly Frames Many = new(4, nameof(Many));
    public static readonly Frames All = new(5, nameof(All));

    private Frames(int value, string name)
        : base(value, name)
    {
    }
}
