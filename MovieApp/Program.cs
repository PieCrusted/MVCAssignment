using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Models;
using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ApplicationCore.Contracts.Repository;
using Infrastructure.Repository;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddRazorRuntimeCompilation gives capabilitie for real time updates when file changes, but is much slower to build
// Not doing AddRazorRuntimeCompilation would mean I will have to refresh build each time to see live changes from file.
builder.Services.AddControllersWithViews();
// builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
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

// Register Repositories
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICastRepository, CastRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ITrailersRepository, TrailersRepository>();
builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();
builder.Services.AddScoped<IMovieCastsRepository, MovieCastsRepository>();
builder.Services.AddScoped<IMovieGenresRepository, MovieGenresRepository>();
builder.Services.AddScoped<IUserRolesRepository, UserRolesRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IFavoritesRepository, FavoritesRepository>();

// Register Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICastService, CastService>();

var app = builder.Build();

// Seed the database
MovieShopDbInitializer.Seed(app.Services);

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