using Entitites.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Concreate.Configurations
{
    public class ProductMapping:IEntityTypeConfiguration<Product>
    {
 
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
            builder.Property(p=>p.ProductName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.PhotoUrl).IsRequired();
            builder.HasOne(c=>c.Category).WithMany(p=>p.Products).HasForeignKey(fk=>fk.CategoryID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
