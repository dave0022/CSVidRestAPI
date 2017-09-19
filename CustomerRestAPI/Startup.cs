using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;

namespace CustomerRestAPI
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();
                var cust = facade.VideoService.Create(
                    new VideoBO() {
                        Title= "Zombies",
                        PricePerDay = "5 USD",
                        Genre= "Horror"
                    });
                facade.VideoService.Create(
                    new VideoBO()
                    {
                        Title = "Blue Skeleton",
                        PricePerDay = "30 USD",
                        Genre = "Comedy"
                    });
                facade.VideoService.Create(
                    new VideoBO()
                    {
                        Title = "Diary of Dracula",
                        PricePerDay = "20 USD",
                        Genre = "Drama"
                    });
                for (int i = 0; i < 50; i++)
                {
                    facade.OrderService.Create(
                        new OrderBO()
                        {
                            DeliveryDate = DateTime.Now.AddMonths(1),
                            OrderDate = DateTime.Now.AddMonths(-1),
                            CustomerId = cust.Id
                        });
                }
            }

            app.UseMvc();
        }
    }
}
