using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        void IEntityTypeConfiguration<Location>.Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(pr => pr.CompanyID);
            object value = builder.Property(m => m.CompanyID).ValueGeneratedOnAdd();
        }
    }
}