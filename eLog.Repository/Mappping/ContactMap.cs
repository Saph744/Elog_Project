using eLog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLog.Repository.Mappping
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        void IEntityTypeConfiguration<Contact>.Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(pr => pr.ContactID);
            object value = builder.Property(m => m.ContactID).ValueGeneratedOnAdd();
        }
    }
}
