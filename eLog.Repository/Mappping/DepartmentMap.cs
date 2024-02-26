using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        void IEntityTypeConfiguration<Department>.Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(pr => pr.DepartmentID);
            object value = builder.Property(m => m.DepartmentID).ValueGeneratedOnAdd();
        }
    }
}
