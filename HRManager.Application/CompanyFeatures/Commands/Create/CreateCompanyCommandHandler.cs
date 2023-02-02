using HRManager.Application.CompanyFeatures;
using HRManager.API.Persistence;
using HRManager.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HRManager.Application.CompanyFeatures.Commands.Create
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Response>
    {
        private readonly CompanyContext _companyContext;

        public CreateCompanyCommandHandler(CompanyContext context)
        {
            _companyContext = context;
        }

        public async Task<Response> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {

            if (command == null)
            {
                return new Response(StatusCodes.Status400BadRequest);
            }

            var mappedEmployee = MapEmployeeDto(command.Employees);
            var company = new Company(command.Name, command.EstablishmentYear, mappedEmployee);

            await _companyContext.Companies.AddAsync(company);
            await _companyContext.SaveChangesAsync();

            return new Response(new { id = company.ID });
        }

        private ICollection<Employee> MapEmployeeDto(List<CompanyEmployeeDto> employees)
        {
            List<Employee> employeesList = new List<Employee>();
            foreach (var employee in employees)
            {

                employeesList.Add(new Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = DateTime.TryParse(employee.DateOfBirth, out DateTime currentDateTime) ? currentDateTime : new DateTime(),
                    JobTitle = Enum.TryParse(employee.JobTitle, out JobTitle currentJobTitle) ? currentJobTitle : JobTitle.None
                });
            }
            return employeesList;
        }
    }
}