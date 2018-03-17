using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IOC.Application;
using System.Reflection;
using IOC.Services;

namespace IOC
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
            services.AddSingleton<DemoService>();
            services.AddSingleton<IDemo2Service, Demo2Service>();
            AddSingletonServices(services);

            services.AddSingleton<LogService>();
            services.AddSingleton<ExceptionFilter>();
            //services.AddMvc();
            services.AddMvc(x =>
            {
                var provider = services.BuildServiceProvider();
                var filter = provider.GetService<ExceptionFilter>();
                //添加过滤器
                x.Filters.Add(filter);
            });
        }

        private static void AddSingletonServices(IServiceCollection services)
        {
            var asm = Assembly.Load(new AssemblyName("IOC.Services"));
            var serviceTypes = asm.GetTypes()
                                  .Where(x => typeof(IAppService).IsAssignableFrom(x) && !x.GetTypeInfo().IsAbstract);

            foreach (var serviceType in serviceTypes)
            {
                foreach (var serviceInterface in serviceType.GetInterfaces())
                {
                    services.AddSingleton(serviceInterface, serviceType);
                }
            }
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
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
