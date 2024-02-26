using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class LeavePolicySettingMap : IEntityTypeConfiguration<LeavePolicySetting>
    {
        public void Configure(EntityTypeBuilder<LeavePolicySetting> builder)
        {
            builder.HasKey(pr => pr.LeavePolicySettingID);
            object value = builder.Property(m => m.LeavePolicySettingID).ValueGeneratedOnAdd();
        }
    }
}
