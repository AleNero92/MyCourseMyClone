using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MyCourse
{
   public class Startup
   {
      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      public void ConfigureServices(IServiceCollection services)
      {
         //importante per il funzionamento del middleware del metodo Configure
         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         //if (env.IsDevelopment())
         if (env.IsEnvironment("Development"))
         {
            app.UseDeveloperExceptionPage();
         }
         app.UseStaticFiles();

         //aggiungo middleware di routing mvc
         //app.UseMvcWithDefaultRoute(); sotto in modo esplicito e piu modulare
         app.UseMvc(routeBuilder =>
         {
            routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
         });
      }
   }
}
