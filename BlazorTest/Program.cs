using BlazorTest.Data;
using DataAccess.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WebShopServices.Managers;
using WebShopServices.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<ISubCategoryManager, SubCategoryManager>();
builder.Services.AddScoped<ICartManager, CartManager>();
builder.Services.AddAuthentication();
builder.Services.AddDbContext<WebShopDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebShopDb")));
builder.Services.AddScoped<IWebShopDbContext, WebShopDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
