using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class UserLeaveDetailMap : IEntityTypeConfiguration<UserLeaveDetail>
    {
        public void Configure(EntityTypeBuilder<UserLeaveDetail> builder)
        {
            builder.HasKey(pr => pr.UserLeaveID);
            object value = builder.Property(m => m.UserLeaveID).ValueGeneratedOnAdd();
        }
    }

}
