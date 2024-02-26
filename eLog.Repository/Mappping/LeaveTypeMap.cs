using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class LeaveTypeMap : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasKey(pr => pr.LeaveTypeID);
            object value = builder.Property(m => m.LeaveTypeID).ValueGeneratedOnAdd();
        }
    }
}
