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
                var video = facade.VideoService.Create(new VideoBO()
                {
                    Name = "First Video",
                    Price = 100
                });

                facade.GenreService.Create(new GenreBO()
                {
                    Name = "Action",
                    VideoId = video.Id
                });

                video = facade.VideoService.Create(new VideoBO()
                {
                    Name = "Second Video",
                    Price = 200
                });

                facade.GenreService.Create(new GenreBO()
                {
                    Name = "Thriller",
                    VideoId = video.Id
                });

                video = facade.VideoService.Create(new VideoBO()
                {
                    Name = "Third Video",
                    Price = 300
                });
                
                facade.GenreService.Create(new GenreBO()
                {
                    Name = "Comedy",
                    VideoId = video.Id
                });

            }

            app.UseMvc();
        }
    }
}
