using FluentValidation;
using FluentValidation.Results;

namespace HRManager.Application.CompanyFeatures.Queries.Search
{
    public class SearchCompanyQueryValidator : AbstractValidator<SearchCompanyQuery>
    {

        public override ValidationResult Validate(ValidationContext<SearchCompanyQuery> context)
        {
            RuleFor(x => x.EmployeeDateOfBirthTo)
                                .LessThanOrEqualTo(x => x.EmployeeDateOfBirthFrom)
                                .WithMessage("Incorrect DataBirth");

            return base.Validate(context);
        }
    }
}
