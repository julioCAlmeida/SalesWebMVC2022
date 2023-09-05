using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVC2022.Data;
using SalesWebMVC2022.Services;
using System.Configuration;

namespace SalesWebMVC2022
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("SalesWebMVC2022Context");


            builder.Services.AddDbContext<SalesWebMVC2022Context>(options =>
                options.UseMySql(
                    connectionString,
                    ServerVersion.Parse("8.0.30-mysql")
                    ));

            //Add services to the seeding.
            builder.Services.AddScoped<SeedingService>();

            //Add services to the sellerService, departmentService.
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //injected and used to perform data seeding
            var seedingServices = app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>();
            seedingServices.Seed();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}