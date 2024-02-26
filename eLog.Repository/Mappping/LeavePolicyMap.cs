using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class LeavePolicyMap : IEntityTypeConfiguration<LeavePolicy>
    {
        public void Configure(EntityTypeBuilder<LeavePolicy> builder)
        {
            builder.HasKey(pr => pr.LeavePolicyID);
            object value = builder.Property(m => m.LeavePolicyID).ValueGeneratedOnAdd();
        }
    }
}
