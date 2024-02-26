using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class LeaveApprovalMap : IEntityTypeConfiguration<LeaveApproval>
    {
        public void Configure(EntityTypeBuilder<LeaveApproval> builder)
        {
            builder.HasKey(pr => pr.LeaveApprovalID);
            object value = builder.Property(m => m.LeaveApprovalID).ValueGeneratedOnAdd();
        }
    }
}
