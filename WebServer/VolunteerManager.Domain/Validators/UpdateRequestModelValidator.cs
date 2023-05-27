﻿using FluentValidation;
using VolunteerManager.Data.Enums;
using VolunteerManager.Domain.Services.Abstraction;
using VolunteerManager.Domain.Validators.Extensions;
using VolunteerManager.Models.Update;

namespace VolunteerManager.Domain.Validators;

internal class UpdateRequestModelValidator : AbstractValidator<UpdateRequestModel>
{
    public UpdateRequestModelValidator(IValidationService validationService)
    {
        RuleFor(updateRequestModel => updateRequestModel.RequestId)
            .Cascade(CascadeMode.Stop)
            .MustAsync(validationService.IsRequestExistAsync)
            .WithStatusCode(StatusCode.RequestNotFound);

        RuleFor(updateRequestModel => updateRequestModel.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithStatusCode(StatusCode.RequestDescriptionRequired)
            .MaximumLength(2000)
            .WithStatusCode(StatusCode.RequestDescriptionMustHaveNotMoreThan2000Characters);

        RuleFor(updateRequestModel => updateRequestModel.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithStatusCode(StatusCode.RequestNameRequired)
            .MaximumLength(250)
            .WithStatusCode(StatusCode.RequestNameMustHaveNotMoreThan250Characters);

        RuleFor(updateRequestModel => updateRequestModel.TotalAmount)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithStatusCode(StatusCode.TotalAmountRequired);
    }
}