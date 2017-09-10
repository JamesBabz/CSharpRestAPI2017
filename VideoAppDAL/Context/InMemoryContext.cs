using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = 
            new DbContextOptionsBuilder<InMemoryContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        public InMemoryContext() : base(options)
        {
            
        }

        public DbSet<Video> Videoes { get; set; }   
    }
}
