namespace ApiaryManagementSystem.Application.Features.Inspections.Commands.CreateInspection;

using FluentValidation;

public class CreateInspectionCommandValidator : AbstractValidator<CreateInspectionCommand>
{
    public CreateInspectionCommandValidator()
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
