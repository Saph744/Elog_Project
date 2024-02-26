using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLog.Repository.Mappping
{
    public class HolidayDetailMap : IEntityTypeConfiguration<HolidayDetail>
    {
        void IEntityTypeConfiguration<HolidayDetail>.Configure(EntityTypeBuilder<HolidayDetail> builder)
        {
            builder.HasKey(pr => pr.HolidayDetailID);
            object value = builder.Property(m => m.HolidayDetailID).ValueGeneratedOnAdd();
        }


    }
}
