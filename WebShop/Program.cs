using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using WebShop;
using WebShopServices.Managers;
using WebShopServices.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<ISubCategoryManager, SubCategoryManager>();
builder.Services.AddScoped<ICartManager, CartManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddAuthentication();
builder.Services.AddDbContext<WebShopDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebShopDb")));
builder.Services.AddScoped<IWebShopDbContext, WebShopDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<HomeManager>();
builder.Services.AddSession();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapBlazorHub();
app.Run();
