using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.BusinessEngine.Implementaion;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Implementaion;
using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.Mappings;
using AutoMapper;
using EmployeeManagement.Data.DbModels;
using EmployeeManagement.Common.ConstantsModels;

namespace EmployeeManagement.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UdemyEmployeeManagementContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityConnection")));

            services.AddScoped<IEmployeeLeaveTypeBusinessEngine, EmployeeLeaveTypeBusinessEngine>();
            services.AddScoped<IEmployeeLeaveRequestBusinessEngine, EmployeeLeaveRequestBusinessEngine>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Maps));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<UdemyEmployeeManagementContext>();

            services.AddIdentity<Employee, IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<UdemyEmployeeManagementContext>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddMvc();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            SeedData.Seed(userManager, roleManager);
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
