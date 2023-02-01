using System.ComponentModel.DataAnnotations;

namespace HRManager.Domain.Model
{
    public class Company : Entity<long>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int EstablishmentYear { get; set; }
        public ICollection<Employee>? Employees { get; set; }

        public Company() { }
        public Company(string name, int establishmentYear)
        {
            Name = name != null ? name : "UnknownCompany";
            EstablishmentYear = establishmentYear != 0 ? establishmentYear : 0;
        }

        public Company(string name, int establishmentYear, ICollection<Employee> employees = null)
        {
            Name = name != null ? name : "UnknownCompany";
            EstablishmentYear = establishmentYear != 0 ? establishmentYear : 0;
            Employees = employees != null ? employees : new List<Employee>();
        }

        public void Update(string name, int establishmentYear, ICollection<Employee> employees)
        {
            Name = name != null ? name : Name;
            EstablishmentYear = establishmentYear != 0 ? establishmentYear : EstablishmentYear;
            Employees = employees != null ? employees : Employees;

        }

    }
}