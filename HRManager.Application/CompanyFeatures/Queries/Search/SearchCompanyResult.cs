using HRManager.Domain.Model;
using System.Linq.Expressions;

namespace HRManager.Application.CompanyFeatures.Queries.Search
{
    public class SearchCompanyResult
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<SearchEmployeeResult> Employees { get; set; }

        public static Expression<Func<Company, SearchCompanyResult>> Projection
        {
            get
            {
                return x => new SearchCompanyResult
                {
                    Name = x.Name,
                    EstablishmentYear = x.EstablishmentYear,
                    Employees = x.Employees.AsQueryable().Select(SearchEmployeeResult.Projection).ToList()
                };
            }
        }
    }
}
