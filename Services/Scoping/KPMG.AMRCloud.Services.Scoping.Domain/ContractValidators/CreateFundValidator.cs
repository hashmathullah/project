using FluentValidation;
using KPMG.AMRCloud.Services.Scoping.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.AMRCloud.Services.Scoping.Domain.ContractValidators
{
    public class CreateFundValidator: AbstractValidator<CreateFundRequest>
    {

        public CreateFundValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

           
        }
    }
}
