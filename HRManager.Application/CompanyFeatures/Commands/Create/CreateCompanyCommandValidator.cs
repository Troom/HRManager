using FluentValidation;
using FluentValidation.Results;

namespace HRManager.Application.CompanyFeatures.Commands.Create
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public override ValidationResult Validate(ValidationContext<CreateCompanyCommand> context)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nazwa firmy nie moze byc pusta");
            RuleFor(x => x.EstablishmentYear)
                .NotEmpty().WithMessage("Data zalozenia nie moze byc pusta");
            return base.Validate(context);
        }
    }
}