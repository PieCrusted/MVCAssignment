// namespace MovieApp;
//
// public class Program {
//     public static void Main(string[] args) {
//         var builder = WebApplication.CreateBuilder(args);
//
//         // Add services to the container.
//         builder.Services.AddControllersWithViews();
//
//         var app = builder.Build();
//
//         // Configure the HTTP request pipeline.
//         if (!app.Environment.IsDevelopment()) {
//             app.UseExceptionHandler("/Home/Error");
//             // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//             app.UseHsts();
//         }
//
//         app.UseHttpsRedirection();
//         app.UseRouting();
//
//         app.UseAuthorization();
//
//         app.MapStaticAssets();
//         app.MapControllerRoute(
//                 name: "default",
//                 pattern: "{controller=Home}/{action=Index}/{id?}")
//             .WithStaticAssets();
//
//         app.Run();
//     }
// }

using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieService, MovieService>();

// Add Db Context
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddDbContext<MovieShopDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("MovieShopDbConnection")
    .Replace("<secret_key>", configuration.GetConnectionString("MovieShopDbPassword")))
);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();