using System;
using System.Collections.Generic;
using System.IO;
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
      //IApplicationLifetime mi permette di registrare un pezzo di codice che verrà eseguito dopo l avvio dell applicazione
      public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
      {
         //if (env.IsDevelopment())
         if (env.IsEnvironment("Development"))
         {
            app.UseDeveloperExceptionPage();

            lifetime.ApplicationStarted.Register(() =>
            {
               //concateno il nome del path con la directiry bin
               //in settings.json faccio in modo che browsersync controlli i cambiamenti di questo file
               string filePath = Path.Combine(env.ContentRootPath, "bin/reload.txt");
               File.WriteAllText(filePath, DateTime.Now.ToString());
            });
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
