using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    { 
        void IEntityTypeConfiguration<Project>.Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(pr => pr.ProjectID);
            object value = builder.Property(m => m.ProjectID).ValueGeneratedOnAdd();
        }
    }

}
