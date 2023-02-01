using MediatR;

namespace HRManager.Application.CompanyFeatures.Commands.Delete
{
    public class DeleteCompanyCommand : IRequest<Response>
    {
        public long ID { get; set; }

    }
}
