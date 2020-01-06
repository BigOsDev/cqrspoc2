using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.GridItem.Commands
{
    public class GridValueChangeCommandValidator : AbstractValidator<GridValueChangeCommand>
    {
        public GridValueChangeCommandValidator()
        {
            RuleFor(v => v.AgregateId).NotEqual(0).GreaterThan(0);
            RuleFor(v => v.NewValue).NotNull().NotEmpty();
            RuleFor(v => v.OldValue).NotNull().NotEmpty();
            RuleFor(v => v.PropertyName).NotNull().NotEmpty();
        }
    }
}
