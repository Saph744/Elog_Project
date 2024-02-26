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
    public class CompanyMap: IEntityTypeConfiguration<Company>
    {
        void IEntityTypeConfiguration<Company>.Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(pr => pr.CompanyID);
            object value = builder.Property(m => m.CompanyID).ValueGeneratedOnAdd();
        }
    }
}
