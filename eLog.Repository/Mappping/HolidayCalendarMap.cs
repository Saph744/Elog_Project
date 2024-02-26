using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class HolidayCalendarMap : IEntityTypeConfiguration<HolidayCalendar>
    {
        public void Configure(EntityTypeBuilder<HolidayCalendar> builder)
        {
            builder.HasKey(pr => pr.HolidayCalendarID);
            object value = builder.Property(m => m.HolidayCalendarID).ValueGeneratedOnAdd();
        }
    }
}
