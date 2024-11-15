namespace ApiaryManagementSystem.Application.Features.Inspections.Commands.UpdateInspection;

using FluentValidation;

public class UpdateInspectionCommandValidator : AbstractValidator<UpdateInspectionCommand>
{
    public UpdateInspectionCommandValidator()
    {
        RuleFor(x => x.InspectionDate)
            .NotEmpty();

        RuleFor(x => x.ColonyStrength)
            .IsInEnum();

        RuleFor(x => x.FramesWithCappedBrood)
            .IsInEnum();

        RuleFor(x => x.FramesWithUncappedBrood)
            .IsInEnum();

        RuleFor(x => x.FramesWithHoney)
            .IsInEnum();

        RuleFor(x => x.FramesWithPollen)
            .IsInEnum();

        RuleFor(x => x.FramesWithFreeSpace)
            .IsInEnum();

        RuleFor(x => x.BroodPattern)
            .IsInEnum();

        RuleFor(x => x.BeeBehaviour)
            .IsInEnum();

        RuleFor(x => x.SwarmingState)
            .IsInEnum();

        RuleFor(x => x.HiveId)
            .NotEmpty();
    }
}
