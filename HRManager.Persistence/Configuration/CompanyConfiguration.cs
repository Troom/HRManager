using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HRManager.Domain.Model;

namespace HRManager.API.Persistence.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            var naviagtion = builder.Metadata.FindNavigation(nameof(Company.Employees));
            naviagtion.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasKey(c => c.ID);
            builder.HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
