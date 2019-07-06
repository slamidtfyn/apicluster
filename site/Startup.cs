using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using model;

namespace site
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.Run(async (context) =>
            {
            CacheDbService db= new CacheDbService("localhost");
            db.ClearValues();
                var c = new HttpClient();
                List<Task> tasks= new List<Task>();
                for(int t=0;t<100;t++) {
                tasks.Add( c.PostAsJsonAsync("http://localhost:30950/api/values", new Message { name = "Test" }));
                }
                Task.WaitAll(tasks.ToArray());
                
            
                var data=string.Join('\n', db.Values());
                await context.Response.WriteAsync(data);
            });
        }
    }
}
