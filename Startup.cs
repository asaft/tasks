using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using usertasks.DAL;
using usertasks.Models;

namespace usertasks
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

            services.ConfigurePostgreSQLContext(Configuration);

            services.ConfigureMongoDB(Configuration);

            services.ConfigureDependenciesInjections();

            services.ConfigureCronJobs();

            services.AddHostedService<TasksHostedService>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
            InitiateUsersData();
        }

        private void InitiateUsersData()
        {
           var connectionString = Configuration["ConnectionStrings:MyWebApiConection"];
           var seed = new DataSeed(connectionString);
           var user1 = new User{
               Id = 1,
               FirstName ="John",
               LastName = "Smith",
               UserName = "jsmith",
               Password = "123456"
           };
            var user2 = new User{
               Id = 2,
               FirstName ="Eve",
               LastName = "Smith",
               UserName = "esmith",
               Password = "123456"
           };

           seed.InsertUser(user1);
           seed.InsertUser(user2);
        }
    }
}
