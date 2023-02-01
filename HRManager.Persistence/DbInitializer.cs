using HRManager.API.Persistence;
using HRManager.Domain.Model;
using System.Diagnostics;

namespace HRManager.Persistence
{
    public static class DbInitializer
    {

        public static void Initialize(CompanyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Companies.Any())
            {
                return;
            }

            var companies = new Company[]
            {
            new Company{Name="Carson2", EstablishmentYear = 1235},
            new Company{Name="Carson", EstablishmentYear = 1234},
            new Company{Name="Meredith", EstablishmentYear = 321},
            new Company{Name="Arturo", EstablishmentYear = 452},
            new Company{Name="Gytis", EstablishmentYear = 432},
            new Company{Name="Yan", EstablishmentYear = 644},
            new Company{Name="Peggy", EstablishmentYear = 989},
            new Company{Name="Laura", EstablishmentYear = 7777},
            new Company{Name="Nino", EstablishmentYear = 1543}
        };
            foreach (Company s in companies)
            {
                context.Companies.Add(s);
            }
            context.SaveChanges();

            var employers = new Employee[]
            {
            new Employee{CompanyId=1, FirstName = "Mark", LastName = "AAAA", JobTitle = JobTitle.Architekt},
            new Employee{CompanyId=1,FirstName = "Steve", LastName = "BBBB", JobTitle = JobTitle.Administrator},
            new Employee{CompanyId=1,FirstName = "John", LastName = "CCCC", JobTitle = JobTitle.Developer},
            new Employee{CompanyId=2,FirstName = "Susane", LastName = "DDDD", JobTitle = JobTitle.Administrator},
            new Employee{CompanyId=2,FirstName = "Tom", LastName = "EEE", JobTitle = JobTitle.Manager},
            new Employee{CompanyId=2,FirstName = "Jackob", LastName = "FFFF", JobTitle = JobTitle.Developer},
            new Employee{CompanyId=3,FirstName = "Kate", LastName = "GGG", JobTitle = JobTitle.Architekt},
            new Employee{CompanyId=4,FirstName = "Carol", LastName = "HHH", JobTitle = JobTitle.Developer},
            new Employee{CompanyId=4,FirstName = "Henry", LastName = "III", JobTitle = JobTitle.Architekt},
            new Employee{CompanyId=5,FirstName = "Joe", LastName = "JJJ", JobTitle = JobTitle.Architekt},
            new Employee{CompanyId=6,FirstName = "Gregore", LastName = "KKK", JobTitle = JobTitle.Developer},
            new Employee{CompanyId=7,FirstName = "Christine", LastName = "LLL", JobTitle = JobTitle.Developer},
            };
            foreach (Employee e in employers)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();
        }
    }
}
