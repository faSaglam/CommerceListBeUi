using Entities.Concreate;
using Entitites.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccess.Extentions.EfSeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                 new UserRole()
                 {
                     Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                     Name = "User",
                     ConcurrencyStamp = "2",
                     NormalizedName = "User"
                 }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>()
                {
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                }

                );

            User user = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                NormalizedUserName="ADMIN",
                FirstName="Admin",
                LastName="Admin",
                Email = "omfasaglam@gmail.com",
                NormalizedEmail="OMFASAGLAM@GMAIL.COM"


            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");
           

            modelBuilder.Entity<User>().HasData(user);

            
        }

        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
              new Category()
              {
                CategoryID= 1,
                CategoryName = "Gıda"
              },
               new Category()
               {
                   CategoryID = 2,
                   CategoryName = "Hijyen"
               },
               new Category()
                {
                       CategoryID = 3,
                       CategoryName = "Kıyafet"
                },
               new Category()
               {
                   CategoryID=4,
                   CategoryName = "Elektronik"
               },
              new Category()
              {
                 CategoryID = 5,
                 CategoryName = "Kırtasiye"
               }
              );
        }

        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
              new Product()
              {
                 ProductID= 10,
                 ProductName="Salça",
                 CategoryID = 1,
                 PhotoUrl = "https://image.pngaaa.com/811/324811-middle.png"

              },
               new Product()
               {
                   ProductID = 11,
                   ProductName = "Ekmek",
                   CategoryID = 1,
                   PhotoUrl = "https://images.migrosone.com/sanalmarket/product/05120000/05120000-a957e2-1650x1650.jpg"
               },
               new Product()
               {
                   ProductID = 12,
                   ProductName = "Soğan",
                   CategoryID = 1,
                   PhotoUrl = "https://productimages.hepsiburada.net/s/44/375/10818919890994.jpg"
               },
               new Product()
               {
                   ProductID = 21,
                   ProductName = "Bez",
                   CategoryID = 2,
                   PhotoUrl = "https://productimages.hepsiburada.net/s/6/375/9729860632626.jpg"
               },
              new Product()
              {
                  ProductID = 22,
                  ProductName = "Deterjan",
                  CategoryID = 2,
                  PhotoUrl = "https://www.ecolabel.com/images/eco-label/deterjan.jpg"
              },
                 new Product()
                 {
                     ProductID = 23,
                     ProductName = "Sabun",
                     CategoryID = 2,
                     PhotoUrl = "https://cdn.thomasnet.com/insights-images/embedded-images/4399ffd9-4ce9-4ba7-a008-c41bed53921a/cec9fc52-c432-4d7d-8583-77c18c6e7601/FullHD/private-label-soap-suppliers.jpg"
                 },
                 new Product()
                 {
                     ProductID = 31,
                     ProductName = "Tişört",
                     CategoryID = 3,
                     PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMAKVjxVwhCvmhbnjggKlsehqXzaOr0Mi0yA&usqp=CAU"
                 },
              new Product()
              {
                  ProductID = 32,
                  ProductName = "Etek",
                  CategoryID = 3,
                  PhotoUrl = "https://img-incommerce-yargici.mncdn.com/Content/Images/Thumbs/22152666_mor-mini-etek-1yket4104x050.jpeg"
              },
                 new Product()
                 {
                     ProductID = 33,
                     ProductName = "Ceket",
                     CategoryID = 2,
                     PhotoUrl = "https://sarar.com/sarar-jam-lacivert-blazer-ceket-4387-blazer-ceket-sarar-3771-43-K.jpg"
                 },
                 new Product()
                  {
                     ProductID = 41,
                     ProductName = "Mouse",
                     CategoryID = 4,
                     PhotoUrl = "https://www.monofiyat.com/images/thumbs/0009879_mf-product-shift-0112-wireless-mouse-siyah.jpeg"
                 },
              new Product()
              {
                  ProductID = 42,
                  ProductName = "Klavye",
                  CategoryID = 4,
                  PhotoUrl = "https://www.dhresource.com/0x0/f2/albu/g5/M01/F2/54/rBVaJFk0tMqAEu5SAADL85n_65Y599.jpg"
              },
                 new Product()
                 {
                     ProductID = 43,
                     ProductName = "Akıllı Telefon",
                     CategoryID = 4,
                     PhotoUrl = "https://d9v7j6n3.rocketcdn.me/wp-content/uploads/2022/05/oppo-a16-1024x576.jpg"
                 },
                              new Product()
                              {
                                  ProductID = 51,
                                  ProductName = "Defter",
                                  CategoryID = 5,
                                  PhotoUrl = "https://cdn.shopify.com/s/files/1/0266/6967/8627/products/00_defter_ic_9558d3c7-5d3a-4815-b246-03881fd7b46f_700x700.jpg?v=1603360470"
                              },
              new Product()
              {
                  ProductID = 52,
                  ProductName = "Kalem",
                  CategoryID = 5,
                  PhotoUrl = "https://www.ilpen.com.tr/6706-large_default/koseli-naturel-kursun-kalem.jpg"
              },
                 new Product()
                 {
                     ProductID = 53,
                     ProductName = "Silgi",
                     CategoryID = 5,
                     PhotoUrl = "https://bilimgenc.tubitak.gov.tr/sites/default/files/styles/bp-770px-custom_user_desktop_1x/public/silgi_kapak2.jpg?itok=XzuMmKjw"
                 }


              );
        }
    }
}
