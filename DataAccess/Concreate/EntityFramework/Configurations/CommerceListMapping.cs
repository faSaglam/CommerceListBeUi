using Entitites.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.EntityFramework.Configurations
{
    public class CommerceListMapping : IEntityTypeConfiguration<CommerceList>
    {
        public void Configure(EntityTypeBuilder<CommerceList> builder)
        {
            builder.HasKey(c => c.CommerceListID);
            builder.Property(c => c.CommerceListName).HasMaxLength(35);
            builder.Property(c => c.IsOnMarket).HasDefaultValue(false);
         
            builder.HasOne(c => c.Users).WithMany(p=>p.CommerceLists)
                .HasForeignKey(fk=>fk.Id).IsRequired().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
