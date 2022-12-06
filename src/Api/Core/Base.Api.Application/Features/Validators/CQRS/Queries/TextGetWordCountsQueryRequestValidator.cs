using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Common.Models.Constants;
using Base.Common.Models.CQRS.Queries.Request.Text;

namespace Base.Api.Application.Features.Validators.CQRS.Queries;

public class TextGetWordCountsQueryRequestValidator : AbstractValidator<TextGetWordCountsQueryRequest>
{
    public TextGetWordCountsQueryRequestValidator()
    {
        RuleFor(x => x.Url)
            .NotNull().WithMessage(ValidatorConstants.DefaultNullMessage)
            .NotEmpty().WithMessage(ValidatorConstants.DefaultEmptyMessage);

        RuleFor(x => x.CurrentPage)
            .NotNull().WithMessage(ValidatorConstants.DefaultNullMessage)
            .NotEmpty().WithMessage(ValidatorConstants.DefaultEmptyMessage)
            .GreaterThanOrEqualTo(1).WithMessage(ValidatorConstants.DefaultGreaterThanMessage);

        RuleFor(x => x.PageSize)
            .NotNull().WithMessage(ValidatorConstants.DefaultNullMessage)
            .NotEmpty().WithMessage(ValidatorConstants.DefaultEmptyMessage)
            .GreaterThanOrEqualTo(1).WithMessage(ValidatorConstants.DefaultGreaterThanMessage);
    }
}
