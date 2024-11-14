namespace ApiaryManagementSystem.Application.Features.Inspections.Commands.CreateInspection;

using FluentValidation;
using static Domain.Constants.Models.Inspection;

public class CreateInspectionCommandValidator : AbstractValidator<CreateInspectionCommand>
{
    public CreateInspectionCommandValidator()
    {
        RuleFor(x => x.InspectionDate)
            .NotEmpty();

        RuleFor(x => x.FramesWithCappedBrood)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.FramesWithUncappedBrood)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.FramesWithHoney)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.FramesWithPollen)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.FramesWithFreeSpace)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.BroodPattern)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.BeeBehaviour)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.SwarmingState)
            .IsInEnum()
            .NotEmpty();

        RuleFor(x => x.IsQueenPresent)
            .NotEmpty();

        RuleFor(x => x.AreEggsPresent)
            .NotEmpty();

        RuleFor(x => x.AreQueenCellsPresent)
            .NotEmpty();

        RuleFor(x => x.AreDroneCellsPresent)
            .NotEmpty();

        RuleFor(x => x.Notes)
            .MaximumLength(NotesMaxLength)
            .NotEmpty();

        RuleFor(x => x.HiveId)
            .NotEmpty();
    }
}
