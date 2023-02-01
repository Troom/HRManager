using HRManager.API.Persistence;
using HRManager.Application.Auth;
using HRManager.Application.CompanyFeatures.Commands.Create;
using HRManager.Application.CompanyFeatures.Commands.Delete;
using HRManager.Application.CompanyFeatures.Queries.Search;
using HRManager.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRManager.API.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyContext _context;

        public CompanyController(ICompanyRepository companyRepository, CompanyContext context, IMediator mediator)
        {
            _companyRepository = companyRepository;
            _context = context;
            _mediator = mediator;
        }
        [BasicAuthorization]
        [HttpGet]
        public async Task<ActionResult> GetCompanies()
        {
            try
            {
                return Ok(await _companyRepository.GetCompanies());

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        [BasicAuthorization]
        [HttpPost]
        public async Task<ActionResult> CreateOld([FromBody] CreateCompanyCommand company)
        {
            var commandResult = await _mediator.Send(company);
            return Created("", commandResult);
        }
        [BasicAuthorization]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Company company)
        {
            try
            {
                if (company == null)
                {
                    return BadRequest();
                }
                var createdCompany = await _companyRepository.InsertCompany(company);
                return CreatedAtAction(nameof(GetCompanies), new { id = createdCompany }, createdCompany);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest); //Mozna to lepiej oblsuyzc
            }
        }

        [BasicAuthorization]
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Search(SearchCompanyQuery query)
        {
            Console.WriteLine();
            var queryResult = await _mediator.Send(query);
            return Ok(queryResult.Result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCompanyCommand command)
        {
            var commandResult = await _mediator.Send(command);
            return Ok(commandResult.Result);
        }
    }
}
