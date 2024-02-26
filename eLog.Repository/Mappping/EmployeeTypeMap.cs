using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class EmployeeTypeMap : IEntityTypeConfiguration<EmployeeType>
    {
        void IEntityTypeConfiguration<EmployeeType>.Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder.HasKey(pr => pr.EmployeeTypeID);
            object value = builder.Property(m => m.EmployeeTypeID).ValueGeneratedOnAdd();
        }
    }
}