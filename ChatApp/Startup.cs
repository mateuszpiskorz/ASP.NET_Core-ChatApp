using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ChatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddDbContext<ChatDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("UserDBConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
               
                routes.MapRoute(name: "Home", template: "", defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(name: "Login", template: "login", defaults: new { controller = "Authetication", action = "Login" });
                routes.MapRoute(name: "ChatRoom", template: "chat", defaults: new { controller = "Chat", action = "Index" });
                routes.MapRoute(name: "GetContactConversations", template: "contact/conversations/{contact}", defaults: new { controller = "Chat", action = "ConversationWithContact", contact = "" });
                routes.MapRoute(name: "SendMessage", template: "send_message", defaults: new { controller = "Chat", action = "SendMessage" });

            });
                   
               
        }
    }
}
