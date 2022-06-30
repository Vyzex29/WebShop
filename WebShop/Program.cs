using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using WebShopServices.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddDbContext<WebShopDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebShopDb")));
builder.Services.AddSession();
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

app.Run();
