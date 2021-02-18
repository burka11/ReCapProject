using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {

            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c=> c.Description).Must(StartsWithB).WithMessage("Araba açıklamaları B harfi ile başlamalıdır!");
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(5).When(c => c.BrandId == 1);

        }

        private bool StartsWithB(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}
