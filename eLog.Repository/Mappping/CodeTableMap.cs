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
    public class CodeTableMap: IEntityTypeConfiguration<CodeTable>
    {
        void IEntityTypeConfiguration<CodeTable>.Configure(EntityTypeBuilder<CodeTable> builder)
        {
            builder.HasKey(pr => pr.ID);
            object value = builder.Property(m => m.ID).ValueGeneratedOnAdd();
        }
    }
}
