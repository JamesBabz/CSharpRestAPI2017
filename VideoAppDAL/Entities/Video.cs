﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
