using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Context
{
    class VideoAppContext : DbContext
    {
        static DbContextOptions<VideoAppContext> options = 
            new DbContextOptionsBuilder<VideoAppContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        public VideoAppContext() : base(options)
        {
            
        }

        public DbSet<Video> Videoes { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
