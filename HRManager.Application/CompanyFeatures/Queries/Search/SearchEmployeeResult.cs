using HRManager.Domain.Model;
using System.Linq.Expressions;

namespace HRManager.Application.CompanyFeatures.Queries.Search
{
    public class SearchEmployeeResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string JobTitle { get; set; }

        public static Expression<Func<Employee, SearchEmployeeResult>> Projection
        {
            get
            {
                return e => new SearchEmployeeResult
                {
                    DateOfBirth = e.DateOfBirth.ToString("yyyy-MM-dd"),
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle.ToString()
                };
            }
        }
    }
}
