using HRManager.API.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HRManager.Application.CompanyFeatures.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCompanyCommand, Response>
    {
        private readonly CompanyContext _context;

        public DeleteCommandHandler(CompanyContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.Include(x => x.Employees).Where(x => x.ID == command.ID).FirstOrDefaultAsync();

            if (company is null)
            {
                return new Response(StatusCodes.Status404NotFound);
            }

            _context.Remove(company);
            await _context.SaveChangesAsync();

            return new Response();
        }



    }
}
