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

        /*public VideoAppContext() : base(options)
        {
            
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:step3457-cs2017.database.windows.net,1433;Initial Catalog=step3457-CS2017;Persist Security Info=False;User ID=step3457;Password=Antonius189!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public DbSet<Video> Videoes { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
