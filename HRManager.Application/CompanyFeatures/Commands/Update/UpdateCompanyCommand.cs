using HRManager.API.Application.CompanyFeatures;
using MediatR;

namespace HRManager.Application.CompanyFeatures.Commands.Update
{
    public class UpdateCompanyCommand : IRequest<Response>
    {
        public long CompanyId { get; protected set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<CompanyEmployeeDto> Employees { get; set; } = new List<CompanyEmployeeDto>();
        public void SetCompanyId(long id)
        {
            CompanyId = id;
        }
    }
}
