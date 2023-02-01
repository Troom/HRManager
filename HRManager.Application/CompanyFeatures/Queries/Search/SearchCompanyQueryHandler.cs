using HRManager.API.Persistence;
using HRManager.Application.CompanyFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Application.CompanyFeatures.Queries.Search
{
    public class SearchCompanyQueryHandler : IRequestHandler<SearchCompanyQuery, Response>
    {

        private readonly CompanyContext _context;

        public SearchCompanyQueryHandler(CompanyContext companyContext)
        {

            _context = companyContext;
        }

        public async Task<Response> Handle(SearchCompanyQuery query, CancellationToken cancellationToken)
        {
            if (!ValidateQuery(query))
            {
                return new Response(StatusCodes.Status400BadRequest);
            }

            var companies = _context.Companies.Include(x => x.Employees).AsQueryable();
            var companies1 = _context.Companies.AsQueryable();

            var filteredCompanies = await companies.Filter(query).ToListAsync();
            var result = filteredCompanies.AsQueryable().Select(SearchCompanyResult.Projection).ToList();

            return new Response(result);
        }

        private bool ValidateQuery(SearchCompanyQuery query)
        {
            if (query.EmployeeDateOfBirthFrom != null &&
                DateTime.TryParse(query.EmployeeDateOfBirthFrom, out DateTime tmp))
            {
                return false;
            }
            if (query.EmployeeDateOfBirthFrom != null &&
                DateTime.TryParse(query.EmployeeDateOfBirthFrom, out DateTime tmp1))
            {
                return false;
            }
            return true;
        }
    }
}
