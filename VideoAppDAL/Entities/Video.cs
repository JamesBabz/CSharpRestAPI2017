using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
