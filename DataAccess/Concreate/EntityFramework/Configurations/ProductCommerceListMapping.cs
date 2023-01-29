using Entitites.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concreate.Configurations
{
    public class ProductCommerceListMapping : IEntityTypeConfiguration<ProductCommerceList>
    {
        public void Configure(EntityTypeBuilder<ProductCommerceList> builder)
        {

            builder.HasKey(id => new { id.ProductID, id.CommerceListID });
            builder.HasOne(cl => cl.CommerceList).WithMany(p => p.Products).HasForeignKey(pcl => pcl.CommerceListID);
            builder.HasOne(p => p.Product).WithMany(cl => cl.CommerceLists).HasForeignKey(pcl => pcl.ProductID);
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(c=>c.IsBought).HasDefaultValue(false);

        }
    }
}
