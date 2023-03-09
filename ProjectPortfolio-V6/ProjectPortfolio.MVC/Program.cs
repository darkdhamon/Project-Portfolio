using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectPortfolio.Model.Data;
using ProjectPortfolio.Model.Data.Repository;
using ProjectPortfolio.MVC.Data;
using ProjectPortfolio.MVC.Models;

namespace ProjectPortfolio.MVC
{
    public class Program
    {
        public static ConfigurationManager? Configuration { get; set; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Configuration = builder.Configuration;
            Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(),true);

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

            SetupRepositories(services);

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            
        }

        private static void SetupRepositories(IServiceCollection services)
        {
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
        }

        private static void SetupDatabaseConnections(IServiceCollection services)
        {

            var identityConnectionString = Configuration.GetConnectionString("MSIdentityConnection")
                                           ?? throw new InvalidOperationException(
                                               "Connection string 'MSIdentityConnection' not found.");
            var identityConnectionBuilder = new SqlConnectionStringBuilder(identityConnectionString);
            
            identityConnectionBuilder.Password = Configuration[$"UserPass:{identityConnectionBuilder.UserID}"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(identityConnectionBuilder.ConnectionString));

            var defaultConnectionString = Configuration.GetConnectionString("DefaultConnection")
                                          ?? throw new InvalidOperationException(
                                              "Connection string 'DefaultConnection' not found.");
            var defaultConnectionBuilder = new SqlConnectionStringBuilder(defaultConnectionString);
            defaultConnectionBuilder.Password = Configuration[$"UserPass:{defaultConnectionBuilder.UserID}"];
            services.AddDbContext<PortfolioContext>(options =>
                options.UseSqlServer(defaultConnectionBuilder.ConnectionString));

            services.AddDbContext<PortfolioContext>(options => options.UseSqlServer(defaultConnectionString));
        }
    }
}