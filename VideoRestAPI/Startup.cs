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
using VideoAppBLL;
using VideoAppBLL.BusinessObjects;

namespace VideoRestAPI
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

                //Default videos
                var facade = new BLLFacade();

                var genre = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Action"
                });

                facade.VideoService.Create(new VideoBO()
                {
                    Name = "First Video",
                    Price = 100,
                    GenreId = genre.Id
                });

                genre = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Thriller"
                });

                facade.VideoService.Create(new VideoBO()
                {
                    Name = "Second Video",
                    Price = 200,
                    GenreId = genre.Id
                });

                genre = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Comedy"
                });

                facade.VideoService.Create(new VideoBO()
                {
                    Name = "Third Video",
                    Price = 100,
                    GenreId = genre.Id
                });

            }

            app.UseMvc();
        }
    }
}
