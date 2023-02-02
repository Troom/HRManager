using FluentAssertions;
using HRManager.API.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HRManager.API.Tests
{
    public class CompanyControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _client;
        //Wspoldzielony kontekst
        public CompanyControllerTests(WebApplicationFactory<Program> factory) { 
            _client = factory
                        .WithWebHostBuilder(builder=> //Overwrite existing database connection
                        {
                            builder.ConfigureServices(services => {

                                var dbContextOptions = services.SingleOrDefault(x=>
                                                        x.ServiceType == typeof(DbContextOptions<CompanyContext>));

                                services.Remove(dbContextOptions);

                                services.AddDbContext<CompanyContext>(options => //UseInMemoryDatabase instead MS SQL Server
                                                    options.UseInMemoryDatabase("HRManagerDB"));
                            });
                        })
                
                .CreateClient();
        }

        [Fact]
        public async Task GetAll_BasedGet_ReturnOkResult() {
            var response = await _client.GetAsync("/Company/GetCompanies");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
