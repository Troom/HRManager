using HRManager.API.Persistence;
using HRManager.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HRManager.Application.CompanyFeatures.Commands.Update
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Response>
    {
        private readonly CompanyContext _context;
        public UpdateCompanyCommandHandler(CompanyContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _context.Companies.Find(request.CompanyId);
            if (company == null)
            {
                return new Response(StatusCodes.Status400BadRequest);
            }

            var employeesList = MapEmployeeDtoIntoEmployee(request);
            company.Update(request.Name, request.EstablishmentYear, employeesList);
            _context.SaveChanges();

            return new Response();
        }

        private static List<Employee> MapEmployeeDtoIntoEmployee(UpdateCompanyCommand request)
        {
            DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);
            List<Employee> employeesList = new List<Employee>();
            foreach (var item in request.Employees)
            {
                Enum.TryParse(item.JobTitle, out JobTitle myStatus);

                employeesList.Add(new Employee()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    DateOfBirth = DateTime.ParseExact(item.DateOfBirth, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture),
                    JobTitle = myStatus,
                });
                myStatus = default;
            }

            return employeesList;
        }
    }
}
