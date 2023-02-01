using HRManager.Application.CompanyFeatures.Queries.Search;
using HRManager.Domain.Model;

namespace HRManager.Application.CompanyFeatures.Queries
{
    public static class CompanyFilter
    {
        public static IQueryable<Company> Filter(this IQueryable<Company> query, SearchCompanyQuery filter)
        {
            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                query = query
                    .Where(x => x.Name.Contains(filter.Keyword) ||
                        x.Employees.Any(y =>
                                    y.FirstName.Contains(filter.Keyword) ||
                                    y.LastName.Contains(filter.Keyword)));
            }

            if (filter.EmployeeDateOfBirthFrom != null)
            {
                query = query.Where(x => x.Employees.Any(y =>
                                           y.DateOfBirth > Convert.ToDateTime(filter.EmployeeDateOfBirthFrom)));
            }

            if (filter.EmployeeDateOfBirthTo != null)
            {
                query = query.Where(x => x.Employees.Any(y =>
                                           y.DateOfBirth < Convert.ToDateTime(filter.EmployeeDateOfBirthTo)));
            }

            if (filter.EmployeeJobTitles.Count > 0)
            {
                List<JobTitle> jobTitles = new List<JobTitle>(); //For greater number of jobtitles can be changed into HashList

                foreach (var title in filter.EmployeeJobTitles)
                {
                    var tmpJob = JobTitle.None;
                    Enum.TryParse(title, out tmpJob);
                    if (tmpJob != JobTitle.None)
                    {
                        jobTitles.Add(tmpJob);
                    }
                }
                query = query.Where(x =>
                        x.Employees.Any(y => jobTitles.Contains(y.JobTitle)));
            }

            return query;
        }
    }
}
