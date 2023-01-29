
using DataAccess.Extentions.EfSeedData;
using Entities.Concreate;
using Entitites.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concreate
{
    public class CommerceListDbContext:IdentityDbContext<User,UserRole,string>
    {
        public CommerceListDbContext()
        {

        }
        public CommerceListDbContext(DbContextOptions<CommerceListDbContext> options) : base(options)
        {

        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CommerceListYDb;Trusted_Connection=True");
           


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Seed();//Admin kullanıcısı ve user roleleri
            modelBuilder.SeedCategory();
            modelBuilder.SeedProduct();


            base.OnModelCreating(modelBuilder);
      
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ProductCommerceList> ProductCommerceList { get; set; }
        public virtual DbSet<CommerceList> CommerceLists { get; set; }
        //public virtual DbSet<CategoryMapping> CategoryMappings { get; set; }
        //public virtual DbSet<ProductMapping> ProductMapping { get; set; }
    }
}
