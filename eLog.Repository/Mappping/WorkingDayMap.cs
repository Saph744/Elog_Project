using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class WorkingDayMap:IEntityTypeConfiguration<WorkingDay>
    {
        void IEntityTypeConfiguration<WorkingDay>.Configure(EntityTypeBuilder<WorkingDay> builder)
        {
            builder.HasKey(pr => pr.WorkingDayID);
            object value = builder.Property(m => m.WorkingDayID).ValueGeneratedOnAdd();
        }
    }
}
