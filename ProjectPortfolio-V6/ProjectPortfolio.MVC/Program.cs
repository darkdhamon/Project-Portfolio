using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Model.Data;
using ProjectPortfolio.Model.Data.Repository;
using ProjectPortfolio.MVC.Data;

namespace ProjectPortfolio.MVC
{
    public class Program
    {
        public static ConfigurationManager? Configuration { get; set; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Configuration = builder.Configuration;

            // Add services to the container.
            SetupServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }

        /// <summary>
        /// Set up services for application
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void SetupServices(IServiceCollection services)
        {
            SetupDatabaseConnections(services);

            services.AddTransient<IProjectRepository, ProjectRepository>();

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        private static void SetupDatabaseConnections(IServiceCollection services)
        {
            var defaultConnectionString = Configuration.GetConnectionString("DefaultConnection")
                                          ?? throw new InvalidOperationException(
                                              "Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(defaultConnectionString));
            services.AddDbContext<PortfolioContext>(options => options.UseSqlServer(defaultConnectionString));
        }
    }
}