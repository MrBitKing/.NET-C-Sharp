using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ass1.Models;


namespace Ass1
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = @"Server=localhost;Database=Assignment1; User Id=lab4; Password=lab4; Connection Timeout=30; MultipleActiveResultSets=true";

            // if that fails try: var connection =

            // @"Server=localhost\SQLEXPRESS;Database=Assignment1;Trusted_Connection=True;MultipleActiveResultSets=true";

            services.AddDbContext<Assignment1DataContext>(options => options.UseSqlServer(connection));

            services.AddMvc();

            services.AddMemoryCache();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
    

                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>

            {

                routes.MapRoute(

    name: "default",

    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
