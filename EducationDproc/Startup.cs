using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationDproc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace EducationDproc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<EduContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("ArturEducation4"));
            });



            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                      pattern: "{controller=Home}/{action=Index}/{id?}");

                    //pattern: "{controller=TeacherSignupLogin}/{action=Index}/{id?}");
                    //pattern: "{controller=TeacherSelectEdu}/{action=Index}/{id?}");
                    //pattern: "{controller=TeacherNewEdu}/{action=Index}/{id?}");
                    //pattern: "{controller=TeacherEduList}/{action=Index}/{id?}");  
                    //pattern: "{controller=StudentsEduCopyTeacher}/{action=Index}/{id?}");

                    //pattern: "{controller=TeacherFinish}/{action=Index}/{id?}");


                    //pattern: "{controller=StartEdu}/{action=Index}/{id?}");
                    //pattern: "{controller=StudentsSignupLogin}/{action=Index}/{id?}/{password?}");
                    //pattern: "{controller=StudentsEdu}/{action=Index}/{id?}");
                    //pattern: "{controller=TrueAnswer}/{action=Index}/{id?}");

                    //pattern: "{controller=StudentsFinish}/{action=Index}/{id?}");

                   

            });
        }
    }
}
