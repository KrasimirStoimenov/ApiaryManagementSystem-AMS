﻿namespace ApiaryManagementSystem.Application.Features.Diseases.Commands.CreateDisease;

using FluentValidation;

using static Domain.Constants.Models.Common;
using static Domain.Constants.Models.Disease;

public class CreateDiseaseCommandValidator : AbstractValidator<CreateDiseaseCommand>
{
    public CreateDiseaseCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(NameMinLength)
            .MaximumLength(NameMaxLength)
            .NotEmpty();

        RuleFor(x => x.Treatment)
            .MinimumLength(TreatmentMinLength)
            .MaximumLength(TreatmentMaxLength)
            .NotEmpty();

        RuleFor(x => x.Description)
            .MaximumLength(DescriptionMaxLength);

        RuleFor(x => x.HiveId)
            .NotEmpty();
    }
}
