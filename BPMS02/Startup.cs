using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BPMS02.Models;
using Microsoft.EntityFrameworkCore;
using BPMS02.IRepository;
using BPMS02.Repository;
using BPMS02.Data;

namespace BPMS02
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
            var connection = "Data Source=127.0.0.1;Database=BPMS02;User ID=sa;Password=jky123!";
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));    //使用sql server
                                                                                                //services.AddDbContext<DataContext>(options=>options.UseSqlite(connection)); //使用localdb

            services.AddOptions();
            services.Configure<PageSettings>(Configuration.GetSection("PageSettings"));
            
            //Register application services.
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IBridgeRepository, BridgeRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();



            app.UseMvc(routes =>
            {

                routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
