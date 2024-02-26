
using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        void IEntityTypeConfiguration<Role>.Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(pr => pr.RoleID);
            object value = builder.Property(m => m.RoleID).ValueGeneratedOnAdd();
        }
    }
}
