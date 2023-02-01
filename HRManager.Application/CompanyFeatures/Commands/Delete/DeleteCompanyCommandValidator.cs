using FluentValidation;
using FluentValidation.Results;

namespace HRManager.Application.CompanyFeatures.Commands.Delete
{
    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public override ValidationResult Validate(ValidationContext<DeleteCompanyCommand> context)
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("Id firmy do usuniecia nie moze byc puste");
            //Not implemented yet
            return base.Validate(context);
        }
    }
}
