using HRManager.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HRManager.API.Persistence
{
    public interface ICompanyRepository : IDisposable
    {
        IQueryable All();
        Task<IEnumerable<Company>> GetCompanies();
        Company GetCompanyByID(int companyId);
        Task<long> InsertCompany(Company company);
        void DeleteStudent(int companyID);
        void UpdateStudent(Company company);
        void Save();
    }
    public class CompanyRepository : ICompanyRepository
    {
        private CompanyContext context;



        public CompanyRepository(CompanyContext context)
        {
            this.context = context;
        }
        public IQueryable All()
        {
            return context.Companies.AsQueryable();
        }


        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await context.Companies.ToListAsync();
        }

        public Company GetCompanyByID(int companyId)
        {
            return context.Companies.Find(companyId);
        }

        public async Task<long> InsertCompany(Company company)
        {
            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();
            return company.ID;
        }
        public void DeleteStudent(int companyID)
        {
            Company company = context.Companies.Find(companyID);
            context.Companies.Remove(company);
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateStudent(Company company)
        {
            context.Entry(company).State = EntityState.Modified;
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }


        class MyClass
        {
            public int a { get; set; }
        }

        class MyClass1
        {

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
