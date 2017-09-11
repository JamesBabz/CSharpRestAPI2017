using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppBLL.BusinessObjects
{
    public class GenreBO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int VideoId { get; set; }
        public VideoBO Video { get; set; }
    }
}
