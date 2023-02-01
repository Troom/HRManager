using HRManager.API.Application.CompanyFeatures;
using MediatR;

namespace HRManager.Application.CompanyFeatures.Commands.Create
{
    public class CreateCompanyCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<CompanyEmployeeDto> Employees { get; set; } = new List<CompanyEmployeeDto>();
    }
}