
using Business.Abstract;
using Business.Concreate;
using DataAccess.Abstract;
using DataAccess.Concreate;
using Entities.Concreate;
using Entitites.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CommerceListDbContext>(opt => opt.UseSqlServer(conString));
builder.Services.AddIdentity<User,UserRole>().AddEntityFrameworkStores<CommerceListDbContext>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireDigit = true;
    opt.Password.RequireNonAlphanumeric = false;
});
builder.Services.ConfigureApplicationCookie(options =>
 {
     options.LoginPath = new PathString("/User/Login");
     options.LogoutPath = new PathString("/User/Logout");
     options.AccessDeniedPath = new PathString("/Home/AccessDenied");

     options.Cookie = new()
     {
         Name = "IdentityCookie",
         HttpOnly = true,
         SecurePolicy = CookieSecurePolicy.Always,

     };
     options.ExpireTimeSpan = TimeSpan.FromDays(30);
 }
);

builder.Services.AddAuthentication();

builder.Services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddSession();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<ICommerceListService, CommerceListManager>();
builder.Services.AddScoped<ICommerceListDal, EfCommerceListDal>();
builder.Services.AddScoped<IProductCommerceListService, ProductCommerceListManager>();
builder.Services.AddScoped<IProductCommerceListDal, EfProductCommerceListDal>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
